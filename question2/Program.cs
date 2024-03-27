using Newtonsoft.Json;
using question2;
using System.Text;

class Program
{
    static void Main()
    {
        //veriyi oku ve stringe at.
        string json = File.ReadAllText("C:\\Users\\Selcan\\source\\repos\\question2\\question2\\response.json");

        //kontrol
        if (json != null)
        {
            //deserialize et.
            List<ReceiptModel> receiptModel = JsonConvert.DeserializeObject<List<ReceiptModel>>(json);

            //çiftlemesin diye locale'leri kaldırdım.
            var orderedReceiptModel = receiptModel.Where(s => s.locale == null).ToList();

           var result = GetResult(orderedReceiptModel);

            //Birden fazla gelmemesi için
            foreach (var item in result.Distinct())
            {
                Console.WriteLine(item);
            }

        }
        else
        {
            Console.WriteLine("Parse Edilen Json Formatı Hatalı ya da Boş!!");
        }
    }

    //sonuçlarını getir
    static List<string> GetResult(List<ReceiptModel> model)
    {
        List<string> result = new List<string>();
        foreach (var item in model)
        {
            //tüm liste içinde koordinatlara bakarak kimin yukarıda kimin aşağıda ya da kimin sağda kimin solda olduğunu bulabilmek için.
            var a = model.Where(s => (
            ((s.boundingPoly.maxY + s.boundingPoly.minY) / 2 < item.boundingPoly.maxY)
            &&
            ((s.boundingPoly.maxY + s.boundingPoly.minY) / 2 > item.boundingPoly.minY)
            ))
            .OrderBy(x => x.boundingPoly.vertices[0].x).ToList().Select(m => m.description);

            //Elemanları sıra ile getirmek için.
            //Elemanların yanlarına boşluk eklemek için.
            StringBuilder b = new StringBuilder();
            foreach (var it in a)
            {
                b.Append(it);
                b.Append(" ");
            }

            result.Add(b.ToString());
        }

        return result;

    }
}



