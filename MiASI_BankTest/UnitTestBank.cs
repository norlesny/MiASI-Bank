using System;
using MiASI_Bank;
using Xunit;

namespace MiASI_BankTest
{
    public class UnitTestBank
    {
        private IBank _bank;
        
        public UnitTestBank()
        {
            _bank = new Bank();
        }
        
        [Fact]
        public void Test_DodajRachunek_Powinien_Zakonczyc_Sie_Sukcesem()
        {
            //Arrange
            Wlasciciel wlasciciel = new Wlasciciel("test");
            _bank.PodajLiczbeRachunkow(out var spodziewanaLiczbaRachunkow);
            spodziewanaLiczbaRachunkow++;
            
            //Act
            var result = _bank.DodajRachunek(wlasciciel, out var rachunek);
            
            _bank.PodajLiczbeRachunkow(out var liczbaRachunkow);
                
            //Verify
            Assert.True(result, "Dodanie rachunku nie powiodlo sie");
            Assert.NotNull(rachunek);
            Assert.Equal(spodziewanaLiczbaRachunkow, liczbaRachunkow);
        }
        
        [Fact]
        public void Test_ZamknijRachunek_Powinien_Zmniejszyc_Liczbe_Rachunkow()
        {
            //Arrange
            Wlasciciel wlasciciel = new Wlasciciel("test");
            _bank.DodajRachunek(wlasciciel, out _);
            _bank.PodajLiczbeRachunkow(out var spodziewanaLiczbaRachunkow);
            spodziewanaLiczbaRachunkow--;
            
            //Act
            var result = _bank.ZamknijRachunek(wlasciciel);
            
            _bank.PodajLiczbeRachunkow(out var liczbaRachunkow);
            
            //Verify
            Assert.True(result, "Zamkniecie rachunku nie powiodlo sie");
            Assert.Equal(spodziewanaLiczbaRachunkow, liczbaRachunkow);
        }
        
        [Fact]
        public void Test_DodajLokate_Powinna_Zwiekszyc_Liczbe_Lokat()
        {
            //Arrange
            var wlasciciel = new Wlasciciel("test");
            var kwota = new Kwota(100);
            _bank.DodajRachunek(wlasciciel, out var rachunek);
            rachunek.WplacGotowke(kwota);
            _bank.PodajLiczbeLokat(wlasciciel, out var spodziewanaLiczbaLokat);
            spodziewanaLiczbaLokat++;
            
            //Act
            var result = _bank.DodajLokate(wlasciciel, kwota, out _);
            
            _bank.PodajLiczbeLokat(wlasciciel, out var liczbaLokat);
                
            //Verify
            Assert.True(result, "Dodanie rachunku nie powiodlo sie");
            Assert.Equal(spodziewanaLiczbaLokat, liczbaLokat);
        }
        
        [Fact]
        public void Test_ZerwijLokate_Powinien_Zmniejszyc_Liczbe_Lokat()
        {
            //Arrange
            var kwota = new Kwota(100);
            Wlasciciel wlasciciel = new Wlasciciel("test");
            _bank.DodajRachunek(wlasciciel, out var rachunek);
            rachunek.WplacGotowke(kwota);
            _bank.DodajLokate(wlasciciel, kwota, out var lokata);
            _bank.PodajLiczbeLokat(wlasciciel, out var spodziewanaLiczbaLokat);
            spodziewanaLiczbaLokat--;
            
            //Act
            var result = _bank.ZerwijLokate(wlasciciel, lokata.Numer);
            _bank.PodajLiczbeLokat(wlasciciel, out var liczbaLokat);
            
            //Verify
            Assert.True(result, "Zamkniecie rachunku nie powiodlo sie");
            Assert.Equal(spodziewanaLiczbaLokat, liczbaLokat);
        }
    }
}