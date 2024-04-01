// MIS 3033 001
// Feb 14, 2024
// Diana Huerta 
// 113553066

using b;

Console.WriteLine("DB");

OrderDB db;
db = new OrderDB();

var orders = db.orders.ToList();

for( int i = 0; i < orders.Count; i++ )
{
    Console.WriteLine(orders[i]);
}



