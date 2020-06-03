using System.Linq;
using System;
using Abp.Application.Editions;
using DanielMaldonado.Inquest.Editions;
using DanielMaldonado.Inquest.EntityFramework;
using DanielMaldonado.Inquest.Entity.Location;
using System.Collections.Generic;

namespace DanielMaldonado.Inquest.Migrations.SeedData
{
    public class DefaultLocationCreator
    {
        private readonly InquestDbContext _context;

        public DefaultLocationCreator(InquestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {

            var country = this.createCountry("ECUADOR");
            var province = this.createProvince(country, "LOJA");
            var city = this.createCity(province, "LOJA");
            var branchOffice = this.createBranchOffice(city, "29 DE MAYO");

            province = this.createProvince(country, "MANABI");
            city = this.createCity(province, "PEDERNALES");
            branchOffice = this.createBranchOffice(city, "TARQUI");

            province = this.createProvince(country, "PICHINCHA");
            city = this.createCity(province, "RUMIÑAHUI");
            branchOffice = this.createBranchOffice(city, "SAN RAFAEL");

            province = this.createProvince(country, "PICHINCHA");
            city = this.createCity(province, "RUMIÑAHUI");
            branchOffice = this.createBranchOffice(city, "SAN RAFAEL");
            city = this.createCity(province, "QUITO");
            branchOffice = this.createBranchOffice(city, "MENA 2");
            branchOffice = this.createBranchOffice(city, "QUICENTRO NORTE");

            province = this.createProvince(country, "GUAYAS");
            city = this.createCity(province, "GUAYAQUIL");
            branchOffice = this.createBranchOffice(city, "GUASMO");
        }

        private BranchOffice createBranchOffice(City city, string name)
        {
            var branchOffice = _context.BranchOfficeList.FirstOrDefault(e => e.Name == name);
            if (branchOffice == null)
            {
                branchOffice = new BranchOffice { Id = Guid.NewGuid(), Name = name, City = city, CreationTime = DateTime.Now, CreatorUserId = 2 };
                _context.BranchOfficeList.Add(branchOffice);
                _context.SaveChanges();
            }

            return branchOffice;
        }

        private City createCity(Province province, string name)
        {
            var city = _context.CityList.FirstOrDefault(e => e.Name == name);

            if (city == null)
            {
                city = new City { Id = Guid.NewGuid(), Name = name, Province = province, CreationTime = DateTime.Now, CreatorUserId = 2 };
                _context.CityList.Add(city);
                _context.SaveChanges();
            }

            return city;
        }

        private Province createProvince(Country country, string name)
        {
            var province = _context.ProvinceList.FirstOrDefault(e => e.Name == name);

            if (province == null)
            {
                province = new Province { Id = Guid.NewGuid(), Name = name, Country = country, CreationTime = DateTime.Now, CreatorUserId = 2 };
                _context.ProvinceList.Add(province);
                _context.SaveChanges();
            }

            return province;
        }

        private Country createCountry(string name)
        {
            var country = _context.CountryList.FirstOrDefault(e => e.Name == name);

            if (country == null)
            {
                country = new Country { Id = Guid.NewGuid(), Name = name, CreationTime = DateTime.Now, CreatorUserId = 2 };
                _context.CountryList.Add(country);
                _context.SaveChanges();

            }
            return country;
        }
    }
}