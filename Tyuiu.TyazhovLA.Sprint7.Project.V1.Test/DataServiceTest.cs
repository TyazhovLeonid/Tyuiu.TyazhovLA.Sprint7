using Tyuiu.TyazhovLA.Sprint7.Project.V1.Lib;
namespace Tyuiu.TyazhovLA.Sprint7.Project.V1.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckGetDataValid ()
        {
            DataService ds = new DataService ();
            var res = ds.GetData("C:\\Users\\myach\\OneDrive\\Рабочий стол\\test.csv");
            string[,] wait = { {"А555АА777", "Toyota", "Розовый", "700" } };
            CollectionAssert.AreEqual(wait,res);
        }
    }
}