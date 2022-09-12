namespace DI_Demo.Model
{
    public class Products
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public double pPrice { get; set; }

        static List<Products> pList = new List<Products>()
        {
            new Products(){ pId=101, pName="Pepsi", pCategory="Cold-Drinks", pPrice=50},
            new Products(){ pId=102, pName="Coke", pCategory="Cold-Drinks", pPrice=50},
            new Products(){ pId=103, pName="Maggie", pCategory="Fast-Food", pPrice=50},
            new Products(){ pId=104, pName="IPhone", pCategory="Electronics", pPrice=50},
            new Products(){ pId=105, pName="Dell", pCategory="Electronics", pPrice=50},
        };

        public List<Products> GetALlProduct()
        {
            return pList;
        }

        public Products GetProductById(int id)
        {
            var p = pList.Find(p => p.pId == id);
            return p;
        }
    }
}
