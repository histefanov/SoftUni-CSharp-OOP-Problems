using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType.ToLower();
            this.BakingTechnique = bakingTechnique.ToLower();
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                var flourTypeModifier = this.FlourType switch
                {
                    "white" => 1.5,
                    "wholegrain" => 1.0,
                    _ => 1
                };
                var bakingTechniqueModifier = this.BakingTechnique switch
                {
                    "crispy" => 0.9,
                    "chewy" => 1.1,
                    "homemade" => 1.0,
                    _ => 1
                };
                return (2 * this.Weight) * flourTypeModifier * bakingTechniqueModifier;
            }
        }
    }
}
