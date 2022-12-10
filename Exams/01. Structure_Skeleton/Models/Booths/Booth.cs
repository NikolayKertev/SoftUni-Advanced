using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;
        private double currentBill = 0;
        private double turnover = 0;

        private Booth()
        {
            DelicacyMenu = new DelicacyRepository();
            CocktailMenu = new CocktailRepository();
        }
        public Booth(int boothId, int capacity)
            : this()
        {
            BoothId = boothId;
            Capacity = capacity;
        }

        public int BoothId { get; private set; }
        public int Capacity 
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }

                capacity = value;
            }
        }
        public IRepository<IDelicacy> DelicacyMenu { get; private set; }
        public IRepository<ICocktail> CocktailMenu { get; private set; }
        public double CurrentBill 
        {
            get => currentBill;
            private set
            {
                currentBill = value;
            }
        }
        public double Turnover
        {
            get => turnover;
            private set
            {
                turnover = value;
            }
        }
        public bool IsReserved { get; private set; }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }
        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }
        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Turnover: {Turnover:f2} lv")
                .AppendLine($"-Cocktail menu:");

            foreach (var cocktail in CocktailMenu.Models)
            {
                if (!(cocktail == null))
                {
                    sb.AppendLine($"--{cocktail.ToString()}");
                }
            }
            sb.AppendLine("-Delicacy menu:");
            foreach (var delicacy in DelicacyMenu.Models)
            {
                if (!(delicacy == null))
                {
                    sb.AppendLine($"--{delicacy.ToString()}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
