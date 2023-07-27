using System;

namespace MauiAppToTest.Models
{
	public class Address
	{
        /// <summary>
        /// Gets or sets the street address
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the city location
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state location
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the address postal code
        /// </summary>
        public string PostalCode { get; set; }

        public string County { get; set; }

        /// <summary>
        /// Gets or sets the address Country
        /// </summary>
        public string Country { get; set; }

        // Used for displaying an address in the app with a line break after the street address
        public string AddressFormatted
        {
            get
            {
                string result = string.Empty;
                if (!string.IsNullOrWhiteSpace(this.Street))
                {
                    result += this.Street + "\n";
                }

                if (!string.IsNullOrWhiteSpace(this.City))
                {
                    result += this.City + ", ";
                }

                if (!string.IsNullOrWhiteSpace(this.State))
                {
                    result += this.State + " ";
                }

                if (!string.IsNullOrWhiteSpace(this.PostalCode))
                {
                    result += this.PostalCode;
                }

                return result;
            }
        }

        // Used for linking to external map apps for directions
        public string AddressUrlFormatted
        {
            get
            {
                string addressUrl = string.Empty;
                addressUrl += Street == null ? string.Empty : Street.Replace(" ", "+") + "+";
                addressUrl += City == null ? string.Empty : City.Replace(" ", "+") + "+";
                addressUrl += State == null ? string.Empty : State.Replace(" ", "+") + "+";
                addressUrl += PostalCode == null ? string.Empty : PostalCode.Replace(" ", "+");

                return addressUrl;
            }
        }

        /// <summary>
        /// Deep clones this model.
        /// </summary>
        /// <returns>A deep cloned model.</returns>
        public Address Clone()
        {
            var clone = new Address();

            PopulateClone(clone);

            return clone;
        }

        /// <summary>
        /// Populates a clone with all the current properties of this model
        /// </summary>
        /// <param name="clone">The cloned model to populate.</param>
        public void PopulateClone(Address clone)
        {
            clone.Street = Street;
            clone.City = City;
            clone.State = State;
            clone.PostalCode = PostalCode;
            clone.County = County;
            clone.Country = Country;
        }
    }
}
