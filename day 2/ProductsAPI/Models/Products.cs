namespace ProductsAPI.Models
{
    public class Products
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public double pPrice { get; set; }
        public bool pIsInStock { get; set; }
        public string pCategory { get; set; }

        static List<Products> pList = new List<Products>()
        {
             new Products(){ pId=101, pName="Pepsi", pCategory="Cold-Drink", pIsInStock=true, pPrice=50},
             new Products(){ pId=102, pName="Coke", pCategory="Cold-Drink", pIsInStock=false, pPrice=75},
             new Products(){ pId=103, pName="Iphone", pCategory="Electronics", pIsInStock=true, pPrice=150000},
        };
     
        public List<Products> GetAllProducts()
        {
            return pList;
        }

        public Products GetProductById(int pId)
        {
            var p = pList.Find(pr => pr.pId == pId);
            if (p!=null)
            {
                return p;
            }
            throw new Exception("Product not in store");

        }

        public List<Products> ProductsInStock(bool isAvailable)
        {
            var p = pList.FindAll(pr => pr.pIsInStock == isAvailable);
            return p;
        }

        public List<Products> ProductsByCategory(string category)
        {
            var p = pList.FindAll(pr => pr.pCategory == category);
            return p;
        }


        public string AddProduct(Products newProduct)
        {
            pList.Add(newProduct);
            return "Product Added Successfully";
        }

        public string DeleteProduct(int pId)
        {
            var p = pList.Find(pr => pr.pId == pId);
            if (p!=null)
            {
                pList.Remove(p);
                return "Product Removed Successfully";
            }
            throw new Exception("Product not found")
           
        }

        public string EditProduct(Products changes)
        {
            var p = pList.Find(pr => pr.pId == changes.pId);
            if (p!=null)
            {
                p.pName = changes.pName;
                p.pPrice = changes.pPrice;
                p.pCategory = changes.pCategory;
                p.pIsInStock = changes.pIsInStock;
                return "Product Updated Successfully";
            }
            throw new Exception("Product not found");
        }





    }
}
