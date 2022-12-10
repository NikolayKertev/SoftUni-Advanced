using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> boothRepository;

        public Controller()
        {
            boothRepository = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothID = boothRepository.Models.Count + 1;
            IBooth booth = new Booth(boothID, capacity);
            boothRepository.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, boothID, capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != typeof(Gingerbread).Name && delicacyTypeName != typeof(Stolen).Name)
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            var booths = boothRepository.Models;
            IBooth tempBooth = null;

            foreach (var booth in booths)
            {
                if (booth.BoothId == boothId)
                {
                    tempBooth = booth;
                }
            }

            var delicacies = tempBooth.DelicacyMenu.Models;

            foreach (var delicacy in delicacies)
            {
                if (delicacy.Name == delicacyName)
                {
                    return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
                }
            }

            IDelicacy delicacyToAdd = null;

            if (delicacyTypeName == typeof(Gingerbread).Name)
            {
                delicacyToAdd = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == typeof(Stolen).Name)
            {
                delicacyToAdd = new Stolen(delicacyName);
            }

            tempBooth.DelicacyMenu.AddModel(delicacyToAdd);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }
        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != typeof(Hibernation).Name && cocktailTypeName != typeof(MulledWine).Name)
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            var booths = boothRepository.Models;
            IBooth tempBooth = null;

            foreach (var booth in booths)
            {
                if (booth.BoothId == boothId)
                {
                    tempBooth = booth;
                }
            }

            var cocktails = tempBooth.CocktailMenu.Models;

            foreach (var cocktail in cocktails)
            {
                if (cocktail.Name == cocktailName && cocktail.Size == size)
                {
                    return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
                }
            }

            ICocktail cocktailToAdd = null;

            if (cocktailTypeName == typeof(Hibernation).Name)
            {
                cocktailToAdd = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == typeof(MulledWine).Name)
            {
                cocktailToAdd = new MulledWine(cocktailName, size);
            }

            tempBooth.CocktailMenu.AddModel(cocktailToAdd);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }
        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> orderedBooths = new List<IBooth>();
            var booths = boothRepository.Models;

            foreach (var booth in booths)
            {
                if (booth.IsReserved == false && booth.Capacity >= countOfPeople)
                {
                    orderedBooths.Add(booth);
                }
            }

            orderedBooths = orderedBooths.OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).ToList();

            var firstBooth = orderedBooths.FirstOrDefault();

            if (firstBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            firstBooth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, firstBooth.BoothId, countOfPeople);
        }
        public string TryOrder(int boothId, string order)
        {
            var booths = boothRepository.Models;
            IBooth tempBooth = null;

            foreach (var booth in booths)
            {
                if (booth.BoothId == boothId)
                {
                    tempBooth = booth;
                }
            }

            string[] orderTokens = order.Split("/");
            string itemTypeName;
            string itemName;
            int count;
            string size = null;
            string result = null;

            for (int i = 0; i < orderTokens.Length; i += 3)
            {
                itemTypeName = orderTokens[i];
                itemName = orderTokens[i + 1];
                count = int.Parse(orderTokens[i + 2]);
                string type = "delicacy";

                if (itemTypeName == typeof(MulledWine).Name || itemTypeName == typeof(Hibernation).Name)
                {
                    size = orderTokens[i + 3];
                    i++;
                    type = "cocktail";
                }

                if (itemTypeName != typeof(MulledWine).Name && itemTypeName != typeof(Hibernation).Name 
                    && itemTypeName != typeof(Gingerbread).Name && itemTypeName != typeof(Stolen).Name)
                {
                    return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
                }

                bool exists = false;

                switch (type)
                {
                    case "delicacy":
                        var delicacies = tempBooth.DelicacyMenu.Models;
                        
                        foreach (var delicacy in delicacies)
                        {
                            if (delicacy.Name == itemName)
                            {
                                exists = true;
                            }
                        }

                        if (!exists)
                        {
                            return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                        }

                        foreach (var delicacy in delicacies)
                        {
                            if (delicacy.Name == itemName && delicacy.GetType().Name == itemTypeName)
                            {
                                tempBooth.UpdateCurrentBill(delicacy.Price * count);

                                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
                            }
                        }

                        result = string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                        break;
                    case "cocktail":
                        var cocktails = tempBooth.CocktailMenu.Models;

                        foreach (var cocktail in cocktails)
                        {
                            if (cocktail.Name == itemName && cocktail.GetType().Name == itemTypeName)
                            {
                                exists = true;
                            }
                        }

                        if (!exists)
                        {
                            return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                        }

                        foreach (var cocktail in cocktails)
                        {
                            if (cocktail.Name == itemName && cocktail.Size == size && cocktail.GetType().Name == itemTypeName)
                            {
                                tempBooth.UpdateCurrentBill(cocktail.Price * count);

                                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
                            }
                        }

                        result =  string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                        break;
                }
            }
            return result;
        }
        public string LeaveBooth(int boothId)
        {
            var booths = boothRepository.Models;
            IBooth tempBooth = null;

            foreach (var booth in booths)
            {
                if (booth.BoothId == boothId)
                {
                    tempBooth = booth;
                }
            }

            var bill = tempBooth.CurrentBill;

            tempBooth.Charge();
            tempBooth.ChangeStatus();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {bill:f2} lv")
                .AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().Trim();
        }
        public string BoothReport(int boothId)
        {
            var booths = boothRepository.Models;
            IBooth tempBooth = null;

            foreach (var booth in booths)
            {
                if (booth.BoothId == boothId)
                {
                    tempBooth = booth;
                }
            }

            return tempBooth.ToString();
        }
    }
}
