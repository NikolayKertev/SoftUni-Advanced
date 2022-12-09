﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();
        public void Add(IFormulaOneCar car)
        {
            models.Add(car);
        }

        public bool Remove(IFormulaOneCar car)
        {
            return models.Remove(car);
        }

        public IFormulaOneCar FindByName(string name)
            => models.FirstOrDefault(c => c.Model == name);
    }
}
