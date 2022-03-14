using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class Car
    {
        public Car()
        {
            CarEquipments = new HashSet<CarEquipment>();
            CarImages = new HashSet<CarImage>();
        }

        private int id;
        private string carNumber;
        private int? productionYear;
        private int price;
        private bool? secondHand;
        private DateTime addingDate;
        private int? userId;
        private int? fuelType;
        private string description;
        private string model;
        private int cilindricCapacity;
        private int? brandId;
        private int? carTypeId;

        private Brand brand;
        private CarType carType;
        private FuelType fuelTypeNavigation;
        private User user;
        private ICollection<CarEquipment> carEquipments;
        private ICollection<CarImage> carImages;

        public int Id { get => id; set => id = value; }
        public string CarNumber { get => carNumber; set => carNumber = value; }
        public int? ProductionYear { get => productionYear; set => productionYear = value; }
        public int Price { get => price; set => price = value; }
        public bool? SecondHand { get => secondHand; set => secondHand = value; }
        public DateTime AddingDate { get => addingDate; set => addingDate = value; }
        public int? UserId { get => userId; set => userId = value; }
        public int? FuelType { get => fuelType; set => fuelType = value; }
        public string Description { get => description; set => description = value; }
        public string Model { get => model; set => model = value; }
        public int CilindricCapacity { get => cilindricCapacity; set => cilindricCapacity = value; }
        public int? BrandId { get => brandId; set => brandId = value; }
        public int? CarTypeId { get => carTypeId; set => carTypeId = value; }
        public Brand Brand { get => brand; set => brand = value; }
        public CarType CarType { get => carType; set => carType = value; }
        public FuelType FuelTypeNavigation { get => fuelTypeNavigation; set => fuelTypeNavigation = value; }
        public User User { get => user; set => user = value; }
        public ICollection<CarEquipment> CarEquipments { get => carEquipments; set => carEquipments = value; }
        public ICollection<CarImage> CarImages { get => carImages; set => carImages = value; }
    }
}
