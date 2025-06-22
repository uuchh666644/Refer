using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace afterservice
{
    class GuestClass
    {
        DBconnect connect = new DBconnect();

        public bool insertOrder(string oid, DateTime oDate, string name, string email, string Phone, string request, string state)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `info`(`OrderID`, `OrderDate`, `Name`, `Email`, `Phone`,`Request`, `state`) VALUES(@oid, @odate, @name, @email, @phone, @request, @state)", connect.getconnection);

            command.Parameters.Add("@oid",MySqlDbType.VarChar).Value = oid;
            command.Parameters.Add("@odate", MySqlDbType.VarChar).Value = oDate;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = Phone;
            command.Parameters.Add("@request", MySqlDbType.VarChar).Value = request;
            command.Parameters.Add("@state", MySqlDbType.VarChar).Value = state;


            connect.openConnect();
            if(command.ExecuteNonQuery() ==1)
            { 
                connect.closeConnect();
                return true;
                
                
                }
            else 
            {
                connect.closeConnect();
                return false;
                
                
                }


        }
        public bool insertpminvrtity( string pmname, string destion,byte[]img)
        {
            MySqlCommand command = new MySqlCommand(
        "INSERT INTO `maprinventry` (`description`, `name`,  `pmimg`) VALUES (@destion, @pmname, @img)",
        connect.getconnection
    );

            command.Parameters.Add("@destion", MySqlDbType.VarChar).Value = destion;
            command.Parameters.Add("@pmname", MySqlDbType.VarChar).Value = pmname;
            
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;


            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;


            }
            else
            {
                connect.closeConnect();
                return false;


            }


        }
        public DataTable getGuestlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `info`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
            
            }


        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
        public bool updateInwardRecord(int inID, string supplier, string itemname, string quantity, string price, DateTime indate, string state )
        {
            MySqlCommand command = new MySqlCommand(
        "UPDATE `inwardrecord` SET `Supplier`=@sp, `ItemName`=@itn, `Quantity`=@qu, `price`=@pr, `Dateti`=@Dt, `state`=@st WHERE `inID`=@id",
        connect.getconnection
    );
            command.Parameters.Add("@sp", MySqlDbType.VarChar).Value = supplier;
            command.Parameters.Add("@itn", MySqlDbType.VarChar).Value = itemname;
            command.Parameters.Add("@qu", MySqlDbType.VarChar).Value = quantity;
            command.Parameters.Add("@pr", MySqlDbType.VarChar).Value = price;
            command.Parameters.Add("@Dt", MySqlDbType.VarChar).Value = indate;
            command.Parameters.Add("@st", MySqlDbType.VarChar).Value = state;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = inID;
            connect.openConnect();
            bool success = command.ExecuteNonQuery() == 1;
            connect.closeConnect();
            return success;
        }
        public DataTable getreqlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT ReqId,CreatedBy,remark,CreateTime,productName,price,IMG FROM `requirements`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
        public bool insertinrecord(string supplier, string itemname, string quantity, string price, DateTime indate, string personcharge)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `inwardrecord`(`Supplier`, `ItemName`, `Quantity`, `price`, `Dateti`, `Personcharge`) VALUES(@sp, @itn, @qu, @pr, @Dt, @pc)",
        connect.getconnection);

            command.Parameters.Add("@sp", MySqlDbType.VarChar).Value = supplier;
            command.Parameters.Add("@itn", MySqlDbType.VarChar).Value = itemname;
            command.Parameters.Add("@qu", MySqlDbType.VarChar).Value = quantity;
            command.Parameters.Add("@pr", MySqlDbType.VarChar).Value = price;
            command.Parameters.Add("@Dt", MySqlDbType.VarChar).Value = indate;
            command.Parameters.Add("@pc", MySqlDbType.VarChar).Value = personcharge;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;


            }
            else
            {
                connect.closeConnect();
                return false;


            }
        }
        public DataTable getRecordlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `inwardrecord`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getRecordkeylist(string columnName, string keyword)
        {
            // Validate columnName against a whitelist to avoid SQL injection
            string[] validColumns = { "price", "Supplier", "Quantity", "ItemName", "Dateti", "inID" };
            if (!validColumns.Contains(columnName))
                throw new ArgumentException("Invalid column name.");

            string query = $"SELECT * FROM `inwardrecord` WHERE `{columnName}` LIKE @keyword";
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getMaprInventoryList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `maprinventry`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getMaprInventoryByColumn(string columnName, string keyword)
        {
            // Validate columnName against a whitelist to avoid SQL injection
            string[] validColumns = { "PMID", "description", "name", "pmimg", "Quantity" };
            if (!validColumns.Contains(columnName))
                throw new ArgumentException("Invalid column name.");

            string query = $"SELECT * FROM `maprinventry` WHERE `{columnName}` LIKE @keyword";
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getMaprInventoryByColumnAndType(string columnName, string keyword)
        {
            
            string[] validColumns = { "PMID", "description", "name", "pmimg", "Quantity" };
            if (!validColumns.Contains(columnName))
                throw new ArgumentException("Invalid column name.");

            string query = $"SELECT * FROM `maprinventry` WHERE  `{columnName}` LIKE @keyword";
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            
            command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool insertorder(string gn, string pro, string phone, string email, string address, DateTime oDate)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `makeorder`(`guestname`, `product`, `phone`, `address`, `email`) VALUES (@gn, @pro, @phone, @address, @email)", connect.getconnection);

            command.Parameters.Add("@gn",MySqlDbType.VarChar).Value = gn;
            command.Parameters.Add("@pro", MySqlDbType.VarChar).Value = pro;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@oDate", MySqlDbType.VarChar).Value = oDate;


            connect.openConnect();
            if(command.ExecuteNonQuery() ==1)
            { 
                connect.closeConnect();
                return true;
                
                
                }
            else 
            {
                connect.closeConnect();
                return false;
                
                
                }


        }
        public bool UpdateMaprInventoryQuantity(string itemName, int qty)
        {
            MySqlCommand command = new MySqlCommand(
         "UPDATE `maprinventry` SET `Quantity` = IFNULL(`Quantity`,0) + @qty WHERE `name` = @itemName",
         connect.getconnection
     );
            command.Parameters.Add("@qty", MySqlDbType.Int32).Value = qty;
            command.Parameters.Add("@itemName", MySqlDbType.VarChar).Value = itemName;

            connect.openConnect();
            bool success = command.ExecuteNonQuery() > 0;
            connect.closeConnect();
            return success;
        }
        public DataTable getDispathlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `makeorder`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
    }
}
