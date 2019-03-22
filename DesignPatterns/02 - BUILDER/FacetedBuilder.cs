using System;

namespace DesignPatterns.BUILDER
{

    public class Client
    {
        //address
        public string StreetAddress, Postcode, City;

        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class ClientBuilder //facade
    {
        //reference
       protected Client client = new Client();

        public ClientJobBuilder Works => new ClientJobBuilder(client);
        public ClientAddressBuild Lives => new ClientAddressBuild(client);

        public static implicit operator Client(ClientBuilder cb)
        {
            return cb.client;
        }
    }

    public class ClientJobBuilder : ClientBuilder
    {
        public ClientJobBuilder(Client client)
        {
            this.client = client;

        }

        public ClientJobBuilder At(string companyName)
        {
            client.CompanyName = companyName;
            return this;
        }

        public ClientJobBuilder AsA(string position)
        {
            client.Position = position;
            return this;
        }

        public ClientJobBuilder Earning(int amount)
        {
            client.AnnualIncome = amount;
            return this;
        }
    }

    public class ClientAddressBuild : ClientBuilder
    {
        public ClientAddressBuild(Client client)
        {
            this.client = client;
        }

        public ClientAddressBuild At(string streetAddress)
        {
            client.StreetAddress = streetAddress;
            return this;
        }

        public ClientAddressBuild WithPostcode(string postcode)
        {
            client.Postcode = postcode;
            return this;
        }

        public ClientAddressBuild In(string city)
        {
            client.City = city;
            return this;
        }
    }



    public class FacetedBuilder
    {
        public static void exec()
        {
            var cb = new ClientBuilder();
            Client client = cb
                .Works
                    .At("V")
                    .AsA("Developer")
                    .Earning(11800)
                .Lives
                    .At("DNSa")
                    .WithPostcode("000123")
                    .In("FCo");

            Console.WriteLine(client.ToString());
                
        }
    }
}
