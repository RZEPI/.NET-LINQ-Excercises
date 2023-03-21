using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Car> myCars = new List<Car>(){
                new Car("E250", new Engine(1.8, 204, "CGI"), 2009),
                new Car("E350", new Engine(3.5, 292, "CGI"), 2009),
                new Car("A6", new Engine(2.5, 187, "FSI"), 2012),
                new Car("A6", new Engine(2.8, 220, "FSI"), 2012),
                new Car("A6", new Engine(3.0, 295, "TFSI"), 2012),
                new Car("A6", new Engine(2.0, 175, "TDI"), 2011),
                new Car("A6", new Engine(3.0, 309, "TDI"), 2011),
                new Car("S6", new Engine(4.0, 414, "TFSI"), 2012),
                new Car("S8", new Engine(4.0, 513, "TFSI"), 2012)
            };
            BindingList<Car> myCarsBindingList = new BindingList<Car>(myCars);
            CollectionViewSource collectionViewSource = new CollectionViewSource();
            collectionViewSource.Source = myCarsBindingList;
            dataGrid.ItemsSource = collectionViewSource.View;

            MakeQueries(myCars);
            myCars.Sort(new Comparison<Car>(arg1));
            foreach (var car in myCars)
                Console.WriteLine(car.ToString());
            myCars.FindAll(arg2).ForEach(arg3);
        }

        private void MakeQueries(List<Car> list)
        {
            IEnumerable<dynamic> engineQueryES = from car in list
                                where car.model == "A6"
                                let engineType = car.motor.model == "TDI" ? "diesel" : "petrol"
                                group car.motor.horsePower / car.motor.displacement by engineType into engineGroup
                                orderby engineGroup.Average() descending
                                select new
                                {
                                    engineType = engineGroup.Key,
                                    avgHPPL = engineGroup.Average()
                                };
            foreach (var e in engineQueryES)
                Console.WriteLine(e.engineType + ": " + e.avgHPPL);

            IEnumerable<dynamic> engineQueryMB = list.Where(car => car.model == "A6")
                                .Select(car => new
                                {
                                    engineType = car.motor.model == "TDI" ? "diesel" : "petrol",
                                    hppl = car.motor.horsePower / car.motor.displacement
                                }).GroupBy(engine => engine.engineType)
                                     .Select(engineGroup => new
                                     {
                                         engineType = engineGroup.Key,
                                         avgHPPL = engineGroup.Average(engine => engine.hppl)
                                     }).OrderByDescending(engine => engine.avgHPPL);
            foreach (var e in engineQueryMB)
                Console.WriteLine(e.engineType + ": " + e.avgHPPL);
        }
        Comparison<Car> arg1 = delegate (Car car1, Car car2)
        {
            if (car1.motor.horsePower > car2.motor.horsePower)
            {
                return -1;
            }
            else if (car1.motor.horsePower < car2.motor.horsePower)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        };
        Predicate<Car> arg2 = delegate (Car car)
        {
            return car.motor.model == "TDI";
        };
        Action<Car> arg3 = delegate (Car car)
        {
            MessageBox.Show(car.ToString());
        };
    }


}
