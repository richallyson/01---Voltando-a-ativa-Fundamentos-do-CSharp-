using System;

namespace EstudoLista3
{

    public class Product
    {
        public Guid SerialNumber { get; set; }
        public string NomeDoProduto { get; set; }
        public DateTime ValideDate { get; set; }

        public Product(Guid serialNumber, string nomeDoProduto, DateTime valideDate)
        {
            SerialNumber = serialNumber;
            NomeDoProduto = nomeDoProduto;
            ValideDate = valideDate;
        }

        public string SeeValideDate()
        {
            return ValideDate.ToString("dd/MM/yyyy");
        }
    }
}