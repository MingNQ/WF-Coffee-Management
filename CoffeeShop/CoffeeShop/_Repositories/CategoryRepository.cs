using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace CoffeeShop._Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public CategoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region public fields

        /// <summary>
        /// Add new item
        /// </summary>
        /// <param name="itemModel"></param>
        public void Add(ItemModel itemModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using(var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Item values(@itemID, @categoryID,@itemName,@cost)";
                command.Parameters.Add("@itemID", SqlDbType.NVarChar).Value = itemModel.ItemID;
                command.Parameters.Add("@categoryID", SqlDbType.Int).Value = itemModel.CategoryID;
                command.Parameters.Add("@itemName", SqlDbType.NVarChar).Value = itemModel.ItemName;
                command.Parameters.Add("@cost", SqlDbType.Float).Value = itemModel.Cost;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetItemID()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT TOP 1 ItemID FROM Item ORDER BY ItemID DESC";
                var maxItemId = command.ExecuteScalar() as string;

                int currentId = int.Parse(maxItemId.Substring(1));
                int newId = currentId + 1;
                return "I" + newId.ToString("D3");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="ingredientIDs"></param>
        public void AddItemIngredients(string itemID, List<string> ingredientIDs)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                foreach (var ingredientID in ingredientIDs)
                {
                    // Tìm mã ItemIngredientID lớn nhất
                    command.CommandText = "SELECT MAX(ItemIngredientID) FROM ItemIngredient";
                    var maxID = command.ExecuteScalar() as string;

                    // Sinh mã mới
                    int newIDNumber = 1;
                    if (!string.IsNullOrEmpty(maxID))
                    {
                        newIDNumber = int.Parse(maxID.Substring(2)) + 1;
                    }
                    var newID = $"II{newIDNumber:D3}";

                    // insert vào ItemIngredient
                    command.CommandText = "INSERT INTO ItemIngredient (ItemIngredientID, IngredientID, ItemID) " +
                                          "VALUES (@newID, @ingredientID, @itemID)";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@newID", newID);
                    command.Parameters.AddWithValue("@itemID", itemID);
                    command.Parameters.AddWithValue("@ingredientID", ingredientID);

                    command.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="itemID"></param>
        public void Delete(string itemID)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Item where ItemID = @id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = itemID;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Edit item
        /// </summary>
        /// <param name="itemModel"></param>
        public void Edit(ItemModel itemModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Item set CategoryID = @categoryID, ItemName = @name, Cost = @cost where ItemID = @itemID";
                command.Parameters.Add("@itemID", SqlDbType.NVarChar).Value = itemModel.ItemID;
                command.Parameters.Add("@categoryID", SqlDbType.Int).Value = itemModel.CategoryID;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = itemModel.ItemName;
                command.Parameters.Add("@cost", SqlDbType.Float).Value = itemModel.Cost;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDrink"></param>
        /// <returns></returns>
        public List<CategoryModel> GetAllCategories(bool isDrink)
        {
            string query = isDrink ? @"select * from Category where CategoryID in(1,4,5,6)" : 
                                        @"select * from Category where CategoryID in (2,3)";
            var categoryList = new List<CategoryModel>();
            using(var connection = new SqlConnection(connectionString))
            using(var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = query;
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var categoryModel = new CategoryModel();
                        categoryModel.CategoryID = (int)reader[0];
                        categoryModel.CategoryName = reader[1].ToString();
                        categoryList.Add(categoryModel);
                    }
                }
            }
            return categoryList;
        }

        /// <summary>
        /// Get list drink
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ItemModel> GetAllDrink()
        {
            var itemList = new List<ItemModel>();
            using(var connection = new SqlConnection(connectionString)) 
            using(var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select * from Item where CategoryID in(1,4,5,6)";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var itemModel = new ItemModel();
                        itemModel.ItemID = reader[0].ToString();
                        itemModel.CategoryID = (int)reader[1];
                        itemModel.ItemName = reader[2].ToString();
                        itemModel.Cost = float.Parse(reader[3].ToString());
                        itemList.Add(itemModel);
                    }
                }
            }
            return itemList;
        }

        /// <summary>
        /// Get list foods
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ItemModel> GetAllFoods()
        {
            var itemList = new List<ItemModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select * from Item where CategoryID in(2,3)";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var itemModel = new ItemModel();
                        itemModel.ItemID = reader[0].ToString();
                        itemModel.CategoryID = (int)reader[1];
                        itemModel.ItemName = reader[2].ToString();
                        itemModel.Cost = float.Parse(reader[3].ToString());
                        itemList.Add(itemModel);
                    }
                }
            }
            return itemList;
        }

        /// <summary>
        /// Get items by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<ItemModel> GetByValue(string value, bool isDrink)
        {
            var itemList = new List<ItemModel>();
            string itemName = value;
            float cost = float.TryParse(value, out _) ? float.Parse(value) : 0;
            string query = isDrink ? @"Select * from Item where CategoryID in (1,4,5,6) and (ItemName like N'%" + itemName + "%' or Cost = '"+cost+"') ": 
                                    @"Select * from Item where CategoryID in (2,3) and (ItemName like N'%" + itemName + "%' or Cost = '"+cost+"')" ;
            using (var connection = new SqlConnection(connectionString))
            using(var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = query;
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var itemModel = new ItemModel();
                        itemModel.ItemID = reader[0].ToString();
                        itemModel.CategoryID = (int)reader[1];
                        itemModel.ItemName = reader[2].ToString();
                        itemModel.Cost = float.Parse(reader[3].ToString());
                        itemList.Add(itemModel);
                    }
                }
            }
            return itemList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public List<IngredientModel> GetIngredientsByItemID(string itemID)
        {
            var ingredientList = new List<IngredientModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT a.IngredientID, b.IngredientName FROM ItemIngredient a join Ingredient b on a.IngredientID = b.IngredientID WHERE ItemID = @itemID";
                command.Parameters.Add("@itemID", SqlDbType.NVarChar).Value = itemID;
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ingredientModel = new IngredientModel();
                        ingredientModel.IngredientID = reader[0].ToString();
                        ingredientModel.IngredientName = reader[1].ToString();
                        ingredientList.Add(ingredientModel);
                    }
                }
                   
            }
            return ingredientList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="itemIngredientIDs"></param>
        /// <param name="newIngredientList"></param>
        public void EditItemIngredients(string itemID, List<string> itemIngredientIDs, List<IngredientModel> newIngredientList)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                if (itemIngredientIDs.Count < newIngredientList.Count)
                {
                    // Update existing Ingredients
                    for (int i = 0; i < itemIngredientIDs.Count; i++)
                    {
                        command.CommandText = "UPDATE ItemIngredient SET IngredientID = @ingredientID WHERE ItemIngredientID = @itemIngredientID";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ingredientID", newIngredientList[i].IngredientID);
                        command.Parameters.AddWithValue("@itemIngredientID", itemIngredientIDs[i]);
                        command.ExecuteNonQuery();
                    }

                    // Add new Ingredients
                    for (int i = itemIngredientIDs.Count; i < newIngredientList.Count; i++)
                    {
                        // Find the max ItemIngredientID
                        command.CommandText = "SELECT MAX(ItemIngredientID) FROM ItemIngredient";
                        var maxID = command.ExecuteScalar() as string;

                        // Generate new ID
                        int newIDNumber = 1;
                        if (!string.IsNullOrEmpty(maxID))
                        {
                            newIDNumber = int.Parse(maxID.Substring(2)) + 1;
                        }
                        var newID = $"II{newIDNumber:D3}";

                        // Insert new Ingredient
                        command.CommandText = "INSERT INTO ItemIngredient (ItemIngredientID, IngredientID, ItemID) VALUES (@newID, @ingredientID, @itemID)";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@newID", newID);
                        command.Parameters.AddWithValue("@itemID", itemID);
                        command.Parameters.AddWithValue("@ingredientID", newIngredientList[i].IngredientID);
                        command.ExecuteNonQuery();
                    }
                }
                else if (itemIngredientIDs.Count > newIngredientList.Count)
                {
                    // Update 
                    for (int i = 0; i < newIngredientList.Count; i++)
                    {
                        command.CommandText = "UPDATE ItemIngredient SET IngredientID = @ingredientID WHERE ItemIngredientID = @itemIngredientID";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ingredientID", newIngredientList[i].IngredientID);
                        command.Parameters.AddWithValue("@itemIngredientID", itemIngredientIDs[i]);
                        command.ExecuteNonQuery();
                    }

                    // Delete 
                    for (int i = newIngredientList.Count; i < itemIngredientIDs.Count; i++)
                    {
                        command.CommandText = "DELETE FROM ItemIngredient WHERE ItemIngredientID = @itemIngredientID";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@itemIngredientID", itemIngredientIDs[i]);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Update all Ingredients as counts are equal
                    for (int i = 0; i < newIngredientList.Count; i++)
                    {
                        command.CommandText = "UPDATE ItemIngredient SET IngredientID = @ingredientID WHERE ItemIngredientID = @itemIngredientID";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ingredientID", newIngredientList[i].IngredientID);
                        command.Parameters.AddWithValue("@itemIngredientID", itemIngredientIDs[i]);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        public void DeleteItemIngredients(string itemID)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from ItemIngredient where ItemID = @id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = itemID;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public List<string> GetItemIngredients(string itemID)
        {
            var ItemIngredientIDs = new List<string>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select ItemIngredientID from ItemIngredient where ItemID = @itemID";
                command.Parameters.Add("@itemID", SqlDbType.NVarChar).Value = itemID;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemIngredientIDs.Add(reader[0].ToString());
                    }
                }
            }
            return ItemIngredientIDs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryModel> GetAll()
        {
            var result = new List<CategoryModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Category";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var category = new CategoryModel();
                        category.CategoryID = Convert.ToInt32(reader[0].ToString());
                        category.CategoryName = reader[1].ToString();
                        result.Add(category);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ItemModel> GetAllItems()
        {
            var result = new List<ItemModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Item";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new ItemModel();
                        item.ItemID = reader[0].ToString();
                        item.CategoryID = Convert.ToInt32(reader[1].ToString());
                        item.ItemName = reader[2].ToString();
                        item.Cost = float.Parse(reader[3].ToString());
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        #endregion
    }
}
