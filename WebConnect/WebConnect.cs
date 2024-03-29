using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.EntityClient;
using System.Transactions;

namespace WebConnect
{
    public class WebConnect
    {
        private WinhotEntities db = new WinhotEntities();
        private string connSQL; 


        public void Create(kratiseis kratisi)
        {
            try {

                using (WinhotEntities ctx = db)
                {
                    bool has = ctx.kratiseis.Any(x => x.dbhotel == kratisi.kwd);
                    if (!has)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {


                            var maxArithmos = ctx.kratiseis.Where(c => c.property == 1).Max(c => c.arithmos);
                            kratisi.imeromkratisis = DateTime.Today;
                            kratisi.s_GUID = Guid.NewGuid();
                            maxArithmos += 1;
                            kratisi.arithmos = maxArithmos;
                            kratisi.synolo = kratisi.sum;
                            kratisi.property = 1;
                            TimeSpan difference = (kratisi.anaxwrisi.Value - kratisi.afixi.Value);
                            kratisi.dwmatia = null;

                            if (String.IsNullOrEmpty(kratisi.dwmatio))
                            {
                                kratisi.dwmatio = null;

                            }
                            ctx.kratiseis.Add(kratisi);

                            ctx.SaveChanges();
                            var kratisikwd = kratisi.kwd;
                            //db.Entry(kratisi).State = EntityState.Modified;
                            //db.SaveChanges();
                            if (kratisi.xrewsi == "0")
                            {
                                kratisi.xrewsi = "1";
                            }
                            var timesKr = new timeskratisis { kratisi = kratisikwd, xrewsi = int.Parse(kratisi.xrewsi), apo = kratisi.afixi, mexri = kratisi.anaxwrisi, imeres = (Byte)difference.TotalDays, ypnos = kratisi.ypnos, prwino = kratisi.prwino, synolo = kratisi.sum, touristperiod = kratisi.touristperiod, s_GUID = Guid.NewGuid() };

                            var onomKrat = new enilikes { kratisi = kratisikwd, onomateponimo = kratisi.onoma, s_GUID = Guid.NewGuid() };
                            var statKrat = new status { kratisi = kratisikwd, dwmatio = kratisi.dwmatio, enarxi = kratisi.afixi, lixi = kratisi.anaxwrisi.Value.AddDays(-1), dwmatiostatus = 1, s_GUID = Guid.NewGuid() };
                            ctx.timeskratisis.Add(timesKr);
                            ctx.enilikes.Add(onomKrat);
                            ctx.status.Add(statKrat);
                            //   db.kratiseis.Remove(kratisi);
                            ctx.SaveChanges();

                            scope.Complete();

                        }


                    }
                    else
                    {
                        throw new Exception("Reservation with this ID already exists on Webserver!");
                    }


                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            


        }

        public void Update(kratiseis kratisi)
        {

            try {
                using (WinhotEntities ctx = db)
                {
                    bool has = ctx.kratiseis.Any(x => x.dbhotel == kratisi.kwd);
                    if (has)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {

                            var kratisiFromDB = ctx.kratiseis.Single(x => x.dbhotel == kratisi.kwd);

                            kratisiFromDB.praktimologio = kratisi.praktimologio;
                            kratisiFromDB.enilikes = kratisi.enilikes;
                            kratisiFromDB.ethnikotites = kratisi.ethnikotites;
                            kratisiFromDB.epithimia = kratisi.epithimia;
                            kratisiFromDB.voucher = kratisi.voucher;
                            kratisiFromDB.afixi = kratisi.afixi;
                            kratisiFromDB.anaxwrisi = kratisi.anaxwrisi;
                            kratisiFromDB.checkin = kratisi.checkin;
                            kratisiFromDB.tipos = kratisi.tipos;
                            if (String.IsNullOrEmpty(kratisi.dwmatio))
                            {
                                kratisiFromDB.dwmatio = null;


                            }
                            else
                            {
                                kratisiFromDB.dwmatio = kratisi.dwmatio;
                            }

                            kratisiFromDB.prokataboli = kratisi.prokataboli;
                            kratisiFromDB.tilefonomem = kratisi.tilefonomem;
                            kratisiFromDB.synolo = kratisi.synolo;
                            kratisiFromDB.state = null;
                            timeskratisis timesFromDB = ctx.timeskratisis.Single(x => x.kratisi == kratisiFromDB.kwd);
                            if (kratisi.xrewsi == "0")
                            {
                                kratisi.xrewsi = "1";
                            }

                            timesFromDB.xrewsi = int.Parse(kratisi.xrewsi);
                            timesFromDB.ypnos = kratisi.ypnos;
                            timesFromDB.prwino = kratisi.prwino;
                            timesFromDB.apo = kratisi.afixi;
                            timesFromDB.mexri = kratisi.anaxwrisi;
                            TimeSpan difference = (timesFromDB.mexri.Value - timesFromDB.apo.Value);
                            timesFromDB.imeres = (Byte)difference.TotalDays;
                            timesFromDB.synolo = kratisi.synolo;

                            enilikes nameFromDB = ctx.enilikes.Where(x => x.kratisi == kratisi.kwd).First();
                            nameFromDB.onomateponimo = kratisi.onoma;

                            status statKrat = ctx.status.Where(x => x.kratisi == kratisi.kwd).First();
                            statKrat.dwmatio = kratisi.dwmatio;
                            statKrat.enarxi = kratisi.afixi;
                            statKrat.lixi = kratisi.anaxwrisi.Value.AddDays(-1);


                            ctx.Entry(kratisiFromDB).State = EntityState.Modified;
                            ctx.Entry(timesFromDB).State = EntityState.Modified;
                            ctx.Entry(nameFromDB).State = EntityState.Modified;
                            ctx.Entry(statKrat).State = EntityState.Modified;
                            // db.ObjectStateManager.ChangeObjectState(kratisiFromDB, EntityState.Modified);
                            ctx.SaveChanges();

                            scope.Complete();

                        }
                    }
                    else
                    {
                        throw new Exception("Can't find this Reservation on Webserver. Try upload it!");

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         

            
        }
        public void Delete(int id)
        {

            try
            {
                using (WinhotEntities ctx = db)
                {
                    bool has = ctx.kratiseis.Any(x => x.dbhotel == id);
                    if (has)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {

                            kratiseis kratisi = db.kratiseis.SingleOrDefault(x => x.dbhotel == id);
                            timeskratisis timesDB = db.timeskratisis.Single(x => x.kratisi == kratisi.kwd);
                            enilikes enilikesDB = db.enilikes.Where(x => x.kratisi == kratisi.kwd).First();
                            status statDB = db.status.Where(x => x.kratisi == kratisi.kwd).First();
                            db.timeskratisis.Remove(timesDB);
                            db.enilikes.Remove(enilikesDB);
                            db.status.Remove(statDB);
                            db.kratiseis.Remove(kratisi);
                            db.SaveChanges();
                            scope.Complete();

                        }

                    }
                    else
                    {
                        throw new Exception("Can't find this Reservation on Webserver");

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            





        }
        private void transform_connSQL()
        {
             var conn = ConfigurationManager.ConnectionStrings["WinhotEntities"].ConnectionString;
            var efConnectionString = conn;
            var builder = new EntityConnectionStringBuilder(efConnectionString);
            var regularConnectionString = builder.ProviderConnectionString;
            connSQL = regularConnectionString;
        }
        public bool Synchronize(string connAccess, Int16 arkrat, int individual, int simbolaio, int touristperiod)
        {
            transform_connSQL();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlTransaction transaction;
            using (SqlConnection conn = new SqlConnection(connSQL))
            {
              
                adapter.TableMappings.Add("Table", "kratiseis");
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                "select * from dbo.kratiseis where state=@insert or state=@update or state=@delete;", conn);
                // or state=@update or (state=@delete and checkout=@false
                cmd.Parameters.AddWithValue("@insert", 1);
                cmd.Parameters.AddWithValue("@update", 2);
                cmd.Parameters.AddWithValue("@delete", 3);
              //  cmd.Parameters.AddWithValue("@false", false);
              //  cmd.CommandType = CommandType.Text;
                adapter.SelectCommand = cmd;
                //cmd.ExecuteNonQuery();
                DataSet dataSet = new DataSet("Data");
                adapter.Fill(dataSet);

                // Create a second Adapter and Command to get
                // the Timeskratisis table, a child table of Kratiseis.
                SqlDataAdapter timeskratisisAdapter = new SqlDataAdapter();
                timeskratisisAdapter.TableMappings.Add("Table", "timeskratisis");

                SqlCommand productsCommand = new SqlCommand(
                    "SELECT * FROM dbo.timeskratisis t INNER JOIN kratiseis k ON t.kratisi=k.kwd where k.state=@insert or k.state=@update or k.state=@delete;",
                    conn);
                // or k.state=@update or k.state=@delete
                productsCommand.Parameters.AddWithValue("@insert", 1);
                productsCommand.Parameters.AddWithValue("@update", 2);
                productsCommand.Parameters.AddWithValue("@delete", 3);
                productsCommand.CommandType = CommandType.Text;
                timeskratisisAdapter.SelectCommand = productsCommand;

                // Fill the DataSet.
                timeskratisisAdapter.Fill(dataSet);


                // Close the connection.
              
                dataSet.Relations.Add("KratTimes", dataSet.Tables["Kratiseis"].Columns["kwd"],
                dataSet.Tables["timeskratisis"].Columns["kratisi"]);

                SqlDataAdapter enilikesAdapter = new SqlDataAdapter();
                enilikesAdapter.TableMappings.Add("Table", "enilikes");

                SqlCommand enilikesCommand = new SqlCommand(
                    "SELECT * FROM dbo.enilikes t INNER JOIN kratiseis k ON t.kratisi=k.kwd where k.state=@insert;",
                    conn);
                // or k.state=@update or k.state=@delete
                enilikesCommand.Parameters.AddWithValue("@insert", 1);
               
                enilikesCommand.CommandType = CommandType.Text;
                enilikesAdapter.SelectCommand = enilikesCommand;

                // Fill the DataSet.
                enilikesAdapter.Fill(dataSet);


                // Close the connection.

                dataSet.Relations.Add("KratEnilikes", dataSet.Tables["Kratiseis"].Columns["kwd"],
                dataSet.Tables["enilikes"].Columns["kratisi"]);

                transaction = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
               //dataSet,conn , transaction, connAccess,arkrat,simbolaio,touristperiod)
                if (AccesDB_Insert(dataSet, conn, transaction, connAccess, arkrat,individual, simbolaio, touristperiod))
                {

                  
                  transaction.Commit();
                   conn.Close();
                   return true;
               }
               else
               {
                   transaction.Rollback();
                   conn.Close();
                   return false;
               }

               
            }

        }
        
        private bool AccesDB_Insert(DataSet dataset, SqlConnection SQLConn, SqlTransaction  transSQL,String ConnString,  Int16 arkrat,int individual, int simbolaio, int touristperiod)
        {
            OleDbCommand command = new OleDbCommand();
            OleDbTransaction transaction = null;
            int kwdikos = 0;
            string onomateponimo="";
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {


                conn.Open();
                transaction = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                try
                {
                    foreach (DataRow krat in dataset.Tables["kratiseis"].Rows)
                    {
                        //Response.Write("Customer: " + Customer["ContactName"].ToString());


                        if (((byte)krat["state"] == 1 | (byte)krat["state"] == 2) && (krat["dbhotel"] is DBNull))
                        {
                            Console.WriteLine("\t" + krat["kwd"]);
                            foreach (DataRow enilkratisi in krat.GetChildRows(dataset.Relations["KratEnilikes"]))
                            {
                                // Response.Write("Order #" + Order["OrderId"].ToString());
                                //  OleDbCommand command2 = null;
                                onomateponimo = (string)(enilkratisi["onomateponimo"] is DBNull ? "" : enilkratisi["onomateponimo"]);

                            }

                            kwdikos = insert_kratisi(krat, conn, transaction, arkrat, onomateponimo, individual, simbolaio, touristperiod);
                            if (kwdikos != -1)
                            {
                                //if (kwdikos== 2127414389)
                                //{
                                //    Console.WriteLine("t" + "koita edw");
                                //}

                                arkrat += 1;

                                foreach (DataRow timikratisi in krat.GetChildRows(dataset.Relations["KratTimes"]))
                                {
                                    // Response.Write("Order #" + Order["OrderId"].ToString());
                                    //  OleDbCommand command2 = null;
                                    insert_timikratisi(timikratisi, conn, transaction, kwdikos, touristperiod);


                                }

                                SqlCommand updateCommand = new SqlCommand("Update kratiseis SET dbhotel=@dbhotel, simbolaio=@simbolaio,praktoreio=@praktoreio, state=@status where kwd=@kwdikos;");
                                updateCommand.Connection = SQLConn;
                                updateCommand.Transaction = transSQL;
                                updateCommand.Parameters.AddWithValue("@dbhotel", kwdikos);
                                updateCommand.Parameters.AddWithValue("@simbolaio", simbolaio);
                                updateCommand.Parameters.AddWithValue("@praktoreio", individual);
                                updateCommand.Parameters.AddWithValue("@status", 0);
                                updateCommand.Parameters.AddWithValue("@kwdikos", krat["kwd"]);
                                updateCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                return false;
                            }

                        }
                        if ((byte)krat["state"] == 2 && krat["dbhotel"] != null)
                        {

                            kwdikos = update_kratisi(krat, conn, transaction, simbolaio, touristperiod);

                           
                            if (kwdikos != -1 && kwdikos!=0)
                            {
                                foreach (DataRow timikratisi in krat.GetChildRows(dataset.Relations["KratTimes"]))
                                {
                                    // Response.Write("Order #" + Order["OrderId"].ToString());
                                    //  OleDbCommand command2 = null;
                                    if (delete_timeskratisis(conn, transaction, kwdikos))
                                    {
                                        insert_timikratisi(timikratisi, conn, transaction, kwdikos, touristperiod);
                                    }
                                }
                            }
                            else if (kwdikos==-1)
                            {
                                return false;
                            }
                            SqlCommand updateCommand = new SqlCommand("Update kratiseis SET state=@status where kwd=@kwdikos;");
                            updateCommand.Connection = SQLConn;
                            updateCommand.Transaction = transSQL;
                            updateCommand.Parameters.AddWithValue("@status", 0);
                            updateCommand.Parameters.AddWithValue("@kwdikos", krat["kwd"]);
                            updateCommand.ExecuteNonQuery();
                            updateCommand.Parameters.Clear();

                        }
                        if ((byte)krat["state"] == 3 && krat["dbhotel"] != null)
                        {



                            // Response.Write("Order #" + Order["OrderId"].ToString());
                            //  OleDbCommand command2 = null;
                            if (delete_timeskratisis(conn, transaction, (int)krat["dbhotel"]))
                            {
                                delete_kratisi(conn, transaction, (int)krat["dbhotel"]);
                            }



                            SqlCommand deleteeCommand = new SqlCommand("delete status where kratisi=@kwdikos;");
                            deleteeCommand.Connection = SQLConn;
                            deleteeCommand.Transaction = transSQL;

                            deleteeCommand.Parameters.AddWithValue("@kwdikos", krat["kwd"]);
                           
                            deleteeCommand.ExecuteNonQuery();
                            deleteeCommand.Parameters.Clear();

                            deleteeCommand.CommandText = "delete enilikes where kratisi=@kwdikos;";
                            deleteeCommand.Parameters.AddWithValue("@kwdikos", krat["kwd"]);

                            deleteeCommand.ExecuteNonQuery();
                            deleteeCommand.Parameters.Clear();

                            deleteeCommand.CommandText = "delete timeskratisis where kratisi=@kwdikos;";
                            deleteeCommand.Parameters.AddWithValue("@kwdikos", krat["kwd"]);

                            deleteeCommand.ExecuteNonQuery();
                            deleteeCommand.Parameters.Clear();

                            deleteeCommand.CommandText = "delete kratiseis where kwd=@kwdikos;";
                            deleteeCommand.Parameters.AddWithValue("@kwdikos", krat["kwd"]);

                            deleteeCommand.ExecuteNonQuery();
                            deleteeCommand.Parameters.Clear();

                        }
                    }



                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return false;
                }
                transaction.Commit();
                return true;

            }

        }

        private void delete_kratisi(OleDbConnection conn, OleDbTransaction transaction, int p)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                command.Transaction = transaction;
                command.Parameters.AddWithValue("kwd", p);
                command.CommandText = "DELETE FROM kratiseis where (kwd=?)";
                command.ExecuteNonQuery();
                command.Parameters.Clear();
              
            }
            catch
            {
                }
                   
        }


        private bool delete_timeskratisis(OleDbConnection conn,OleDbTransaction  transaction, Int32 kwdikos)
        {
            try{
                 OleDbCommand command = new OleDbCommand();
                 command.Connection = conn;
               command.Transaction = transaction; 
                  command.Parameters.AddWithValue("kwd", kwdikos);
                  command.CommandText = "DELETE FROM timeskratisis where (kratisi=?)";
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                return true;
            }catch{
                return false;
            }
                   
        }
        private int update_kratisi(DataRow kratisi, OleDbConnection conn, OleDbTransaction transaction,int simbolaio, int touristperiod)
        {

            try{
                OleDbCommand command = new OleDbCommand();
           
          
           
                command.Connection = conn;
               command.Transaction = transaction;
                
                command.Parameters.AddWithValue("praktoreio",kratisi["praktoreio"]?? kratisi["praktoreio"]??1);
                command.Parameters.AddWithValue("praktimologio", (int)kratisi["praktimologio"]);
                command.Parameters.AddWithValue("voucher",kratisi["voucher"]);
                command.Parameters.AddWithValue("enilikes",  kratisi["enilikes"]);
                command.Parameters.AddWithValue("paidia",  kratisi["paidia"]);
                command.Parameters.AddWithValue("afixi", kratisi["afixi"]);
             
                command.Parameters.AddWithValue("anaxwrisi",  kratisi["anaxwrisi"]);
                command.Parameters.AddWithValue("klines", kratisi["klines"]);
                command.Parameters.AddWithValue("tipos", (int)kratisi["tipos"]);
                command.Parameters.AddWithValue("guarantie",  kratisi["guarantie"]);
               
                command.Parameters.AddWithValue("dwmatio", kratisi["dwmatio"]);
                
                command.Parameters.AddWithValue("pliromi", kratisi["pliromi"]);
                command.Parameters.AddWithValue("synolo",kratisi["synolo"]?? kratisi["synolo"]??0);
                command.Parameters.AddWithValue("ethnikotites", kratisi["ethnikotites"]);
                command.Parameters.AddWithValue("anzethnikotites",kratisi["anzethnikotites"]);
                command.Parameters.AddWithValue("anzethnikotita2", kratisi["anzethnikotites2"]);
                command.Parameters.AddWithValue("ethnikotites2", kratisi["ethnikotites2"]);
                command.Parameters.AddWithValue("epithimdate",  kratisi["epithimdate"]);
                command.Parameters.AddWithValue("epithimia", kratisi["epithimia"]);
                command.Parameters.AddWithValue("prokataboli",kratisi["prokataboli"]?? kratisi["prokataboli"]?? 0);
                command.Parameters.AddWithValue("prokatdate",kratisi["prokatdate"]);
                command.Parameters.AddWithValue("simetoxi",kratisi["simetoxi"]);
                command.Parameters.AddWithValue("tilefonomem",kratisi["tilefonomem"]);
                command.Parameters.AddWithValue("simbolaio", simbolaio);
                command.Parameters.AddWithValue("ekptosi", kratisi["ekptosi"]?? kratisi["ekptosi"] ?? false);
                command.Parameters.AddWithValue("ekptposo", kratisi["ekptposo"] ?? kratisi["ekptposo"] ?? 0 );
                command.Parameters.AddWithValue("ekptpososto", kratisi["ekptpososto"] ?? kratisi["ekptpososto"] ?? 0);
                command.Parameters.AddWithValue("ekptimeres", kratisi["ekptimeres"]?? kratisi["ekptimeres"] ?? 0 );
                command.Parameters.AddWithValue("fee", kratisi["fee"]?? kratisi["fee"]??0);
                command.Parameters.AddWithValue("checkin",kratisi["checkin"]);
                command.Parameters.AddWithValue("kwd", kratisi["dbhotel"]);
                command.CommandText = @"UPDATE kratiseis SET praktoreio=?,praktimologio=?, voucher=?, enilikes=?, paidia=?, afixi=?,  anaxwrisi=?, klines=?, tipos=?, guarantie=?, dwmatio=?,
                pliromi=?, synolo=?, ethnikotites=?, anzethnikotites=?, anzethnikotites2=?, ethnikotites2=?, epithimdate=?, epithimia=?,
                prokataboli=?, prokatdate=?, simetoxi=?, tilefonomem=?, simbolaio=?, ekptosi=?, ekptposo=?, ekptpososto=?, ekptimeres=?, fee=?, checkin=?, timologio=0 where (kwd=?) and (checkin=false)";
              var n =  command.ExecuteNonQuery();
                command.Parameters.Clear();
                if (n == 1)
                {
                    return (int)kratisi["dbhotel"];
                }
                else
                {
                    return 0;
                }
              
            }   catch (Exception ex){
                Console.WriteLine("\t" + kratisi["dbhotel"]);
                return -1;
            }
            
               

        }

        private int insert_kratisi(DataRow kratisi, OleDbConnection conn,OleDbTransaction transaction ,Int16 arkrat, string onoma,int individual,int simbolaio, int touristperiod)
        {
            OleDbCommand command = new OleDbCommand();
           
            int kwdikos = 0;

            try
            {
               
                    command.Connection = conn;
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@etos", DateTime.Today.Year);
                    command.Parameters.AddWithValue("@arithmos", arkrat);
                    command.Parameters.AddWithValue("@praktoreio", individual);
                    command.Parameters.AddWithValue("@praktimologio", (int)kratisi["praktimologio"]);
                    command.Parameters.AddWithValue("@voucher", kratisi["voucher"]);

                if (!DBNull.Value.Equals(kratisi["enilikes"]))
                {
                    command.Parameters.AddWithValue("@enilikes", kratisi["enilikes"]);
                }
                else
                {
                    command.Parameters.AddWithValue("@enilikes", 1);
                }
                if (!DBNull.Value.Equals(kratisi["paidia"]))
                {
                    command.Parameters.AddWithValue("@paidia", kratisi["paidia"]);
                }
                else
                {
                    command.Parameters.AddWithValue("@paidia", 0);
                }
               
                    command.Parameters.AddWithValue("@afixi", kratisi["afixi"]);
                    if (!DBNull.Value.Equals(kratisi["wra"])){
                        command.Parameters.AddWithValue("@wra", kratisi["wra"] );
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@wra",  DateTime.Now.TimeOfDay);
                    }
                   
                    command.Parameters.AddWithValue("@anaxwrisi", kratisi["anaxwrisi"]);
                    command.Parameters.AddWithValue("@tipos", (int)kratisi["tipos"]);
                    command.Parameters.AddWithValue("@guarantie", kratisi["guarantie"]);
                    command.Parameters.AddWithValue("@dwmatio", kratisi["dwmatio"]);
                    command.Parameters.AddWithValue("@synolo", (float)kratisi["synolo"]);

                    if (!DBNull.Value.Equals(kratisi["anzethnikotites"]))
                    {
                        command.Parameters.AddWithValue("@anzethnikotites", kratisi["@anzethnikotites"]);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@anzethnikotites", 0);
                    }
                    if (!DBNull.Value.Equals(kratisi["anzethnikotites2"]))
                    {
                        command.Parameters.AddWithValue("@anzethnikotites2", kratisi["@anzethnikotites2"]);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@anzethnikotites2", 0);
                    }
                   
                    command.Parameters.AddWithValue("@ethnikotites2", kratisi["ethnikotites2"]);

                    command.Parameters.AddWithValue("@epithimia", kratisi["epithimia"]);

                    if (!DBNull.Value.Equals(kratisi["epithimdate"]))
                    {
                        command.Parameters.AddWithValue("@epithimdate", kratisi["epithimdate"]);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@epithimdate", DateTime.Today.Date);
                    }
                
                if (!DBNull.Value.Equals(kratisi["prokataboli"]))
                    {
                        command.Parameters.AddWithValue("@prokataboli", kratisi["prokataboli"] );
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@prokataboli",  0);
                    }

                if (!DBNull.Value.Equals(kratisi["prokatdate"]))
                {
                    command.Parameters.AddWithValue("@prokatdate", kratisi["prokatdate"]);
                }
                else
                {
                    command.Parameters.AddWithValue("@prokatdate", DateTime.Today.Date);
                }
                 

                    if (!DBNull.Value.Equals(kratisi["simetoxi"]))
                    {
                        command.Parameters.AddWithValue("@simetoxi", kratisi["simetoxi"]);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@simetoxi", 0);
                    }

                   
                    command.Parameters.AddWithValue("@tilefonomem", kratisi["tilefonomem"]);
                    command.Parameters.AddWithValue("@imeromkratisis", kratisi["imeromkratisis"]);
                    command.Parameters.AddWithValue("@simbolaio", (int)simbolaio);

                    command.Parameters.AddWithValue("@ethnikotites", kratisi["ethnikotites"]);

                    command.Parameters.AddWithValue("@checkin", (bool)kratisi["checkin"]);
                    command.Parameters.AddWithValue("@checkin", (bool)kratisi["checkout"]);
                    command.CommandText = @"INSERT INTO kratiseis (etos, arithmos, praktoreio, praktimologio,voucher, enilikes, paidia, afixi, wra, anaxwrisi, 
                 tipos, guarantie,  dwmatio,  synolo, anzethnikotites, anzethnikotites2, ethnikotites2,
               epithimia, epithimdate,prokataboli, prokatdate, simetoxi, tilefonomem, imeromkratisis,simbolaio, ethnikotites, checkin, checkout)
                 values (@etos, @arithmos, @praktoreio, @praktimologio, @voucher, @enilikes, @paidia, @afixi,@wra, @anaxwrisi,  @tipos, @guarantie,  @dwmatio,  @synolo,
                @anzethnikotites, @anzethnikotites2, @ethnikotites2, @epithimia,@epithimdate, @prokataboli, @prokatdate, @simetoxi, @tilefonomem, 
                @imeromkratisis,@simbolaio, @ethnikotites, @checkin, @checkout)";

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();


                    command.Parameters.AddWithValue("etos", DateTime.Today.Year);
                    command.Parameters.AddWithValue("arithmos", arkrat);
                    command.CommandText = "SELECT kwd FROM kratiseis where (etos=?) and (arithmos=?)";
                    OleDbDataReader myReader;
                    myReader = command.ExecuteReader();
                    int counter = 0;
                    while (myReader.Read())
                    {
                        kwdikos = myReader.GetInt32(0);
                        counter = counter + 1;
                    }

                    myReader.Close();
                    command.Parameters.Clear();

                    if (counter != 1)
                    {
                        transaction.Rollback();
                        return -1;
                    }

                    command.Parameters.AddWithValue("aakratisis", arkrat);
                    command.CommandText = "UPDATE etaireia SET  aakratisis=?";
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    arkrat += 1;


                    command.Parameters.AddWithValue("@kwdikos", kwdikos);
                    command.Parameters.AddWithValue("@onoma", onoma);
                //    command.Parameters.AddWithValue("dwmatiostatus", 1);
                    command.CommandText = @"Insert into enilikes (kratisi, onomateponimo) VALUES (@kwdikos, @onoma)";
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("dwmatio", kratisi["dwmatio"]);
                    command.Parameters.AddWithValue("kratsi", kwdikos);
                    command.Parameters.AddWithValue("enarxi", kratisi["afixi"]);
                    command.Parameters.AddWithValue("lixi", kratisi["anaxwrisi"]);
                    command.Parameters.AddWithValue("dwmatiostatus", 1);
                    command.CommandText = @"Insert into status (dwmatio, kratisi, enarxi, lixi, dwmatiostatus) VALUES (dwmatio, kratisi, enarxi, lixi, dwmatiostatus)";
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    return kwdikos;
               
            }
            catch
            {
                return -1;
            }
            
        }

        private void insert_timikratisi(DataRow timikratisi, OleDbConnection conn, OleDbTransaction transaction, Int32 kwdikos, int touristperiod)
        {
            OleDbCommand command = new OleDbCommand();

            try
            {
                command.Connection = conn;
                command.Transaction = transaction;
                command.Parameters.AddWithValue("@kratisi", kwdikos);
                //if (!DBNull.Value.Equals(timikratisi["timi"]))
                //{
                //    command.Parameters.AddWithValue("@timi", timikratisi["@timi"]);
                //}
                //else
                //{
                   
                //}
                command.Parameters.AddWithValue("timi", -1);
                command.Parameters.AddWithValue("apo", timikratisi["apo"]);
                command.Parameters.AddWithValue("mexri", timikratisi["mexri"]);
                command.Parameters.AddWithValue("imeres", timikratisi["imeres"]);
                command.Parameters.AddWithValue("ypnos", timikratisi["ypnos"]);
                command.Parameters.AddWithValue("prwino", timikratisi["prwino"]);
                //if (!DBNull.Value.Equals(timikratisi["geuma"]))
                //{
                //    command.Parameters.AddWithValue("@geuma", timikratisi["@geuma"]);
                //}
                //else
                //{
                //    command.Parameters.AddWithValue("@geuma", 0);
                //}
                command.Parameters.AddWithValue("geuma", 0);
                //if (!DBNull.Value.Equals(timikratisi["deipno"]))
                //{
                //    command.Parameters.AddWithValue("@deipno", timikratisi["@deipno"]);
                //}
                //else
                //{
                //    command.Parameters.AddWithValue("@deipno", 0);
                //}
                command.Parameters.AddWithValue("deipno", 0);
                //if (!DBNull.Value.Equals(timikratisi["extra"]))
                //{
                //    command.Parameters.AddWithValue("@extra", timikratisi["@extra"]);
                //}
                //else
                //{
                //    command.Parameters.AddWithValue("@extra", 0);
                //}
                command.Parameters.AddWithValue("extra", 0);
                command.Parameters.AddWithValue("synolo", timikratisi["synolo"]);
                command.Parameters.AddWithValue("touristperiod", touristperiod);
                command.Parameters.AddWithValue("xrewsi", timikratisi["xrewsi"]);

                command.CommandText = @"INSERT INTO timeskratisis (kratisi, timi,  apo, mexri, imeres, ypnos, prwino, geuma, deipno, extra, synolo, touristperiod, xrewsi)
                    values (@kratisi, timi, apo, mexri, imeres, ypnos, prwino, geuma, deipno, extra, synolo, touristperiod, xrewsi)";
                command.ExecuteNonQuery();
                command.Parameters.Clear();

            }
            catch (Exception ex) 
            {
                
                Console.WriteLine("\t" + kwdikos);
            }
        }


    }
}


