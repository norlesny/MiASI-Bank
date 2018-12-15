using System;
using MiASI_Bank;
using Moq;
using Xunit;

namespace MiASI_BankTest
{
    public class UnitTestBank : TestsBase
    {
        #region Private fields
        
        private IBank _bank;
        private Wlasciciel _wlascicielTestowy;
        private FabrykaRachunkow _fabrykaRachunkow;
        
        #endregion
        
        #region Setup
        
        //Setup
        public UnitTestBank()
        {
            _fabrykaRachunkow = new FabrykaRachunkow();
            _bank = new Bank(_fabrykaRachunkow);
            _wlascicielTestowy = new Wlasciciel("Test");
        }

        #endregion

        #region Helpers
        
        private IRachunekBankowy DodajRachunekTestowy()
        {
            var kwota = new Kwota(100);
                
            _bank.DodajRachunek(_wlascicielTestowy, out var rachunek);
                
            rachunek.WplacGotowke(kwota);
                
            return rachunek;    
        }
        
        #endregion
        
        [Fact]
        public void Test_DodajRachunek_Powinien_Zwiekszyc_Liczbe_Rachunkow()
        {
            //Arrange
            
            _bank.PodajLiczbeRachunkow(out var spodziewanaLiczbaRachunkow);
            spodziewanaLiczbaRachunkow++;
            
            //Act
            var result = _bank.DodajRachunek(_wlascicielTestowy, out var rachunek);
            
            _bank.PodajLiczbeRachunkow(out var liczbaRachunkow);
                
            //Verify
            Assert.True(result, "Dodanie rachunku nie powiodlo sie");
            Assert.NotNull(rachunek);
            Assert.Equal(spodziewanaLiczbaRachunkow, liczbaRachunkow);
        }

        [Fact]
        public void ZamknijRachunek_Powinien_ZamknacWczesniejStworzonyRachunek()
        {
            // Arrange
            var mockRachunek = new Mock<IRachunekBankowy>();

            var factoryMock = new Mock<IFabrykaRachunkow>();
            factoryMock.Setup(factory => factory.StworzRachunek(It.IsAny<Wlasciciel>())).Returns(mockRachunek.Object);

            var bank = new Bank(factoryMock.Object);

            var wlasciciel = new Wlasciciel("test wlasciciel");
            bank.DodajRachunek(wlasciciel, out IRachunekBankowy rachunek);

            // Act
            bank.ZamknijRachunek(wlasciciel);
            
            // Assert
            mockRachunek.Verify(r => r.Zamknij(), Times.Once);
        }
        
        [Fact]
        public void Test_ZamknijRachunek_Powinien_Zmniejszyc_Liczbe_Rachunkow()
        {
            //Arrange
            DodajRachunekTestowy();
            
            _bank.PodajLiczbeRachunkow(out var spodziewanaLiczbaRachunkow);
            spodziewanaLiczbaRachunkow--;
            
            //Act
            var result = _bank.ZamknijRachunek(_wlascicielTestowy);
            
            _bank.PodajLiczbeRachunkow(out var liczbaRachunkow);
            
            //Verify
            Assert.True(result, "Zamkniecie rachunku nie powiodlo sie");
            Assert.Equal(spodziewanaLiczbaRachunkow, liczbaRachunkow);
        }
        
        [Fact]
        public void Test_DodajLokate_Powinna_Zwiekszyc_Liczbe_Lokat()
        {
            //Arrange
            var kwota = new Kwota(100);
            
            DodajRachunekTestowy();
            
            _bank.PodajLiczbeLokat(_wlascicielTestowy, out var spodziewanaLiczbaLokat);
            spodziewanaLiczbaLokat++;
            
            //Act
            var result = _bank.DodajLokate(_wlascicielTestowy, kwota, out _);
            
            _bank.PodajLiczbeLokat(_wlascicielTestowy, out var liczbaLokat);
                
            //Verify
            Assert.True(result, "Dodanie rachunku nie powiodlo sie");
            Assert.Equal(spodziewanaLiczbaLokat, liczbaLokat);
        }
        
        
        [Fact]
        public void Test_ZerwijLokate_Powinien_Zmniejszyc_Liczbe_Lokat()
        {
            //Arrange
            var kwota = new Kwota(100);
            DodajRachunekTestowy();
            _bank.DodajLokate(_wlascicielTestowy, kwota, out var lokata);
            _bank.PodajLiczbeLokat(_wlascicielTestowy, out var spodziewanaLiczbaLokat);
            spodziewanaLiczbaLokat--;
            
            //Act
            var result = _bank.ZerwijLokate(_wlascicielTestowy, lokata.Numer);
            _bank.PodajLiczbeLokat(_wlascicielTestowy, out var liczbaLokat);
            
            //Verify
            Assert.True(result, "Zamkniecie rachunku nie powiodlo sie");
            Assert.Equal(spodziewanaLiczbaLokat, liczbaLokat);
        }

        [Fact]
        public void Test_WplacGotowke_Powinien_WplacicGotowkeNaRachunek()
        {
            //var rachunekTestowy = DodajRachunekTestowy();

            //_bank.WplacGotowke();


        }
        
    }
}