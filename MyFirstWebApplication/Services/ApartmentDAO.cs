using MyFirstWebApplication.Models;
using MySql.Data.MySqlClient;

namespace MyFirstWebApplication.Services
{
    public class ApartmentDAO : IApartmentDataService
    {
        string connectionString = "Server=localhost;Database=lab1;Uid=root;Pwd=134az98x;\r\n";
        //string sqlStatement = "SELECT ap_id, saldo,charges,payments,month_name,year\r\n FROM money \r\n inner join time \r\n on month_id = time.id;";
        List<ApartmentModel> list = new();

        public int Delete(int id)
        {
            string sqlStatement = @"DELETE FROM money WHERE ap_id = @id;
                                    DELETE FROM apartment WHERE id = @id;";

            using (MySqlConnection connection = new(connectionString))
            {

                MySqlCommand sqlCommand = new(sqlStatement, connection);
                sqlCommand.Parameters.AddWithValue("id", id);

                try
                {
                    connection.Open();
                    Console.WriteLine("Apartment has been deleted");
                    return sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return -1;

            }
        }

        public List<ApartmentModel> GetAllApartments()
        {
            string sqlStatement = @"SELECT ap_id,saldo,charges,payments,remaining,month_id,year,month_name
                                    FROM lab1.money INNER JOIN time ON month_id = time.id;";

            using (MySqlConnection connection = new(connectionString))
            {

                MySqlCommand sqlCommand = new(sqlStatement, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new ApartmentModel
                        {
                            Id = (int)reader[0],
                            Saldo = (decimal)reader[1],
                            MonthSaldo = (decimal)reader[2],
                            Paid = (decimal)reader[3],
                            Left = (decimal)reader[4],
                            MonthId = (int)reader[5],
                            Year = (int)reader[6],
                            Month = (string)reader[7]
                        });
                    }


                    Console.WriteLine("Month records have been received");
                    return list;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return list;

            }

            throw new NotImplementedException();
        }

        public ApartmentModel? GetApartmentById(int id, int year, int month)
        {
            ApartmentModel? model = null;
            string sqlStatement = "SELECT ap_id,saldo,charges,payments,remaining,month_id,year,month_name FROM lab1.money INNER JOIN time ON month_id = time.id WHERE year=@year AND month_id=@month_id AND ap_id=@ap_id;";

            using (MySqlConnection connection = new(connectionString))
            {
                MySqlCommand SqlCommand = new(sqlStatement, connection);
                SqlCommand.Parameters.AddWithValue("@year", year);
                SqlCommand.Parameters.AddWithValue("@month_id", month);
                SqlCommand.Parameters.AddWithValue("@ap_id", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = SqlCommand.ExecuteReader();

                    reader.Read();

                    model = new()
                    {
                        Id = (int)reader[0],
                        Saldo = (decimal)reader[1],
                        MonthSaldo = (decimal)reader[2],
                        Paid = (decimal)reader[3],
                        Left = (decimal)reader[4],
                        MonthId = (int)reader[5],
                        Year = (int)reader[6],
                        Month = (string)reader[7]
                    };


                    return model;


                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Record hasn't been found");

                }
                return model;

            }
        }

        public List<ApartmentModel> GetAllApartments(int year)
        {
            string sqlStatement = @"SELECT ap_id,saldo,charges,payments,remaining,month_id,year,month_name
                                    FROM lab1.money INNER JOIN time ON month_id = time.id
                                    WHERE year=@year";

            using (MySqlConnection connection = new(connectionString))
            {

                MySqlCommand sqlCommand = new(sqlStatement, connection);
                sqlCommand.Parameters.AddWithValue("year", year);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new ApartmentModel
                        {
                            Id = (int)reader[0],
                            Saldo = (decimal)reader[1],
                            MonthSaldo = (decimal)reader[2],
                            Paid = (decimal)reader[3],
                            Left = (decimal)reader[4],
                            MonthId = (int)reader[5],
                            Year = (int)reader[6],
                            Month = (string)reader[7]
                        });
                    }


                    Console.WriteLine("Month records have been received");
                    return list;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return list;

            }

        }

        public bool CheckApartment(int id, int year, int month)
        {

            string sqlStatement = @"SELECT ap_id,saldo,charges,payments,remaining,month_id,year,month_name
                                    FROM lab1.money INNER JOIN time ON month_id = time.id
                                    WHERE year=@year AND month_id=@month_id AND ap_id=@ap_id;";

            using (MySqlConnection connection = new(connectionString))
            {
                MySqlCommand SqlCommand = new(sqlStatement, connection);
                SqlCommand.Parameters.AddWithValue("@year", year);
                SqlCommand.Parameters.AddWithValue("@month_id", month);
                SqlCommand.Parameters.AddWithValue("@ap_id", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = SqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Record has been found");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Record hasn't been found");
                        return true;

                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;

            }
        }

        public decimal GetSaldoById(int id)
        {
            string sqlStatement = "SELECT ap_id, saldo,charges,payments,month_name,year\r\n FROM money \r\n inner join time \r\n on month_id = time.id;";
            using (MySqlConnection connection = new(connectionString))
            {
                MySqlCommand sqlCommand = new(sqlStatement, connection);
                sqlCommand.Parameters.Add("id", MySqlDbType.Int32);
                sqlCommand.Parameters["id"].Value = id;


                try
                {
                    connection.Open();
                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                        Console.WriteLine("Data from DB : {0}", reader[0]);

                    return (decimal)reader[0];

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return -1;
                }


            }




        }

        public bool InsertApartment(ApartmentModel model)
        {
            string sqlStatement = @"INSERT INTO lab1.apartment(id) VALUES (@apartment_number);
                                    INSERT INTO lab1.money(ap_id,saldo,charges,payments,remaining,month_id,year) 
                                    VAlUES (@apartment_number,@saldo,@charges,@payments,@remaining,@month_number,@year);";

            string sqlStatement1 = @"INSERT INTO lab1.money(ap_id,saldo,charges,payments,remaining,month_id,year) 
                                    VAlUES (@apartment_number,@saldo,@charges,@payments,@remaining,@month_number,@year);";

            //string sqlStatement2 = @"UPDATE lab1.money SET payments = payments + @payments
            //                        WHERE ap_id = @apartment_number AND month_id=@month_id AND year=@year;

            //                        UPDATE lab1.money SET charges = charges + @charges
            //                        WHERE ap_id = @apartment_number AND month_id=@month_id AND year=@year;

            //                        UPDATE lab1.money SET remaining = remaining + (@charges-@payments)
            //                        WHERE ap_id = @apartment_number AND month_id=@month_id AND year=@year";

            //using (MySqlConnection connection = new(connectionString))
            //{
            //    MySqlCommand sqlCommand;

            //if (!CheckApartment(model.Id, model.Year, model.MonthId))
            //{
            //    sqlCommand = new(sqlStatement2, connection);

            //    sqlCommand.Parameters.AddWithValue("apartment_number", model.Id);
            //    sqlCommand.Parameters.AddWithValue("saldo", model.Saldo);
            //    sqlCommand.Parameters.AddWithValue("charges", model.MonthSaldo);
            //    sqlCommand.Parameters.AddWithValue("payments", model.Paid);
            //    sqlCommand.Parameters.AddWithValue("remaining", model.Left);
            //    sqlCommand.Parameters.AddWithValue("month_id", model.MonthId);
            //    sqlCommand.Parameters.AddWithValue("year", model.Year);

            //    try
            //    {
            //        connection.Open();
            //        Console.WriteLine("Apartment has been updated");
            //        return sqlCommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Apartment hasn't been updated");
            //        Console.WriteLine(ex.Message);
            //    }
            //    return -1;

            //}

            if (!CheckApartment(model.Id, model.Year, model.MonthId))
                return Update(model);

            using (MySqlConnection connection = new(connectionString))
            {
                MySqlCommand sqlCommand;

                {
                    model.Left = model.MonthSaldo - model.Paid + model.Saldo;
                    if (model.MonthId == 1)
                    {
                        sqlCommand = new(sqlStatement, connection);
                    }
                    else
                    {
                        sqlCommand = new(sqlStatement1, connection);
                    }

                    sqlCommand.Parameters.AddWithValue("apartment_number", model.Id);
                    sqlCommand.Parameters.AddWithValue("saldo", model.Saldo);
                    sqlCommand.Parameters.AddWithValue("charges", model.MonthSaldo);
                    sqlCommand.Parameters.AddWithValue("payments", model.Paid);
                    sqlCommand.Parameters.AddWithValue("remaining", model.Left);
                    sqlCommand.Parameters.AddWithValue("month_number", model.MonthId);
                    sqlCommand.Parameters.AddWithValue("year", model.Year);

                    try
                    {
                        connection.Open();
                        Console.WriteLine("Apartment has been added");
                        sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return false;
                }

            }
        }

        public int InsertPayment(ApartmentModel model)
        {

            //string sqlStatement = @"INSERT INTO lab1.money(ap_id,saldo,charges,payments,month_id,year)
            //                        VAlUES (@apartment_number,@saldo,@charges,@payments,@month_number,@year);";



            string sqlStatement = @"UPDATE lab1.money SET payments = payments + @newvalue
                                    WHERE ap_id = @apartment_number AND month_id=@month_id AND year=@year;

                                    UPDATE lab1.money SET remaining = remaining - @newvalue
                                    WHERE ap_id = @apartment_number AND month_id=@month_id AND year=@year";

            using (MySqlConnection connection = new(connectionString))
            {
                MySqlCommand mySqlCommand = new(sqlStatement, connection);
                mySqlCommand.Parameters.AddWithValue("apartment_number", model.Id);
                mySqlCommand.Parameters.AddWithValue("month_id", model.MonthId);
                mySqlCommand.Parameters.AddWithValue("year", model.Year);
                mySqlCommand.Parameters.AddWithValue("newvalue", model.Paid);

                try
                {
                    connection.Open();
                    Console.WriteLine("Payment has been added");
                    return mySqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return -1;

            }



        }

        public bool Update(ApartmentModel model)
        {
            string sqlStatement2 = @"UPDATE lab1.money SET payments = payments + @payments
                                    WHERE ap_id = @apartment_number AND month_id=@month_id AND year=@year;

                                    UPDATE lab1.money SET charges = charges + @charges
                                    WHERE ap_id = @apartment_number AND month_id=@month_id AND year=@year;

                                    UPDATE lab1.money SET remaining = remaining + (@charges-@payments)
                                    WHERE ap_id = @apartment_number AND month_id=@month_id AND year=@year;";

            string sqlStatementYear = @"SELECT year FROM money WHERE ap_id=@ap_id order by year desc;";
            string sqlStatementMonth = @"SELECT month_id FROM money WHERE ap_id=@ap_id AND year=@year order by month_id desc;";
            string sqlRequest = @"SELECT remaining FROM money WHERE ap_id=@ap_id AND year=@year AND month_id=@month_id;";


            //if (model.MonthId == 1)
            //{
            //    sqlStatement2 += @"UPDATE lab1.money SET saldo = saldo+@saldo
            //                       WHERE ap_id = @apartment_number AND month_id=@month_id AND year=@year";
            //}



            using (MySqlConnection connection = new(connectionString))
            {
                MySqlCommand sqlCommand;
                try
                {
                    sqlCommand = new(sqlStatementYear, connection);
                    sqlCommand.Parameters.AddWithValue("ap_id", model.Id);
                    connection.Open();

                    MySqlDataReader mySqlDataReader = sqlCommand.ExecuteReader();
                    mySqlDataReader.Read();
                    int Year = (int)mySqlDataReader[0];

                    sqlCommand = new(sqlStatementMonth, connection);
                    sqlCommand.Parameters.AddWithValue("ap_id", model.Id);
                    sqlCommand.Parameters.AddWithValue("year", Year);

                    mySqlDataReader = sqlCommand.ExecuteReader();
                    mySqlDataReader.Read();
                    int month = (int)mySqlDataReader[0];

                    sqlCommand = new(sqlRequest, connection);
                    sqlCommand.Parameters.AddWithValue("ap_id", model.Id);
                    sqlCommand.Parameters.AddWithValue("year", Year);
                    sqlCommand.Parameters.AddWithValue("month_id", month);


                    mySqlDataReader = sqlCommand.ExecuteReader();
                    mySqlDataReader.Read();
                    decimal remaining = (decimal)mySqlDataReader[0];

                    if (month==12)
                    {
                        month = 1;
                        Year++;
                    }

                    else { month++; }

                    sqlCommand = new(sqlStatement2, connection);

                    sqlCommand.Parameters.AddWithValue("apartment_number", model.Id);
                    sqlCommand.Parameters.AddWithValue("saldo", model.Saldo);
                    sqlCommand.Parameters.AddWithValue("charges", model.MonthSaldo);
                    sqlCommand.Parameters.AddWithValue("payments", model.Paid);
                    sqlCommand.Parameters.AddWithValue("remaining", remaining + model.MonthSaldo - model.Paid);
                    sqlCommand.Parameters.AddWithValue("month_id", month);
                    sqlCommand.Parameters.AddWithValue("year", Year);

                    sqlCommand.ExecuteNonQuery();

                    Console.WriteLine("Apartment has been updated");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Apartment hasn't been updated");
                    Console.WriteLine(ex.Message);
                }
                return false;


            }
        }

        public int Edit(ApartmentModel model)
        {
            string sqlStatementMonth = "UPDATE money SET remaining = remaining + @newValue WHERE ap_id = @ap_id AND year = @year AND month_id >= @month_id;";
            string sqlStatementYear = "UPDATE money SET remaining = remaining + @newValue WHERE ap_id = @ap_id AND year > @year;";
            string sqlStatement = "UPDATE money SET charges = @charges, payments = @payments WHERE ap_id = @ap_id AND year = @year AND month_id = @month_id;";

            using (MySqlConnection connection = new(connectionString))
            {
                try
                {
                    ApartmentModel? OldApartment = GetApartmentById(model.Id, model.Year, model.MonthId);

                    decimal oldVal = OldApartment.MonthSaldo - OldApartment.Paid;
                    decimal newVal = model.MonthSaldo - model.Paid;
                    newVal -= oldVal;


                    MySqlCommand mySqlCommand = new(sqlStatementMonth, connection);
                    mySqlCommand.Parameters.AddWithValue("@ap_id", model.Id);
                    mySqlCommand.Parameters.AddWithValue("@year", model.Year);
                    mySqlCommand.Parameters.AddWithValue("@month_id", model.MonthId);
                    mySqlCommand.Parameters.AddWithValue("@newValue", newVal);

                    connection.Open();
                    mySqlCommand.ExecuteNonQuery();

                    mySqlCommand = new(sqlStatementYear, connection);
                    mySqlCommand.Parameters.AddWithValue("@ap_id", model.Id);
                    mySqlCommand.Parameters.AddWithValue("@year", model.Year);
                    mySqlCommand.Parameters.AddWithValue("@newValue", newVal);

                    mySqlCommand.ExecuteNonQuery();

                    mySqlCommand = new(sqlStatement, connection);
                    mySqlCommand.Parameters.AddWithValue("@ap_id", model.Id);
                    mySqlCommand.Parameters.AddWithValue("@year", model.Year);
                    mySqlCommand.Parameters.AddWithValue("@month_id", model.MonthId);
                    mySqlCommand.Parameters.AddWithValue("@charges", model.MonthSaldo);
                    mySqlCommand.Parameters.AddWithValue("@payments", model.Paid);

                    mySqlCommand.ExecuteNonQuery();

                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                return 0;

            }
        }


    }
}
