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
            var res = ds.GetData("C:\\Users\\myach\\OneDrive\\������� ����\\test.csv");
            string[,] wait = { {"�555��777", "Toyota", "�������", "700" } };
            CollectionAssert.AreEqual(wait,res);
        }
    }
}