using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Assignement_1
{
    public partial class Question_2_ProductPage : Page
    {
        Dictionary<string, string> productImages = new Dictionary<string, string>()
        {
            { "Laptop", "images/laptop.jpg" },
            { "Smartphone", "images/smartphone.jpg" },
            { "Headphones", "images/headphones.jpg" }
        };

        Dictionary<string, string> productPrices = new Dictionary<string, string>()
        {
            { "Laptop", "₹75,000" },
            { "Smartphone", "₹30,000" },
            { "Headphones", "₹3,500" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.Items.Add("Select a product");
                foreach (var product in productImages.Keys)
                {
                    ddlProducts.Items.Add(product);
                }
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = ddlProducts.SelectedItem.Text;
            if (productImages.ContainsKey(selectedProduct))
            {
                imgProduct.ImageUrl = productImages[selectedProduct];
                lblPrice.Text = ""; // Clear price on selection change
            }
            else
            {
                imgProduct.ImageUrl = "";
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selectedProduct = ddlProducts.SelectedItem.Text;
            if (productPrices.ContainsKey(selectedProduct))
            {
                lblPrice.Text = "Price: " + productPrices[selectedProduct];
            }
            else
            {
                lblPrice.Text = "Please select a valid product.";
            }
        }
    }
}
