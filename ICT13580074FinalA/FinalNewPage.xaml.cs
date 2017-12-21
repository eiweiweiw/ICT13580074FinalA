using ICT13580074FinalA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580074FinalA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinalNewPage : ContentPage
    {
        Product product;
        public FinalNewPage()
        {
            InitializeComponent();

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            departmentPicker.Items.Add("ไอที");
            departmentPicker.Items.Add("บัญชี");
            departmentPicker.Items.Add("การตลาด");
            departmentPicker.Items.Add("ผล");


            genderPicker.Items.Add("ชาย");
            genderPicker.Items.Add("หญิง");

            statusPicker.Items.Add("โสด");
            statusPicker.Items.Add("แต่งงานแล้ว");

            if (product != null)
            {
                nameEntry.Text = product.Name;
                lastnameEntry.Text = product.Lastname;
                ageEntry.Text
            }

        }



        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");

            if (isOk)
            {
                if (product == null)
                {
                    var product = new Product();
                    product.Name = nameEntry.Text;
                    product.Lastname = lastnameEntry.Text;
                    product.Age = int.Parse(ageEntry.Text);
                    genderPicker.SelectedItem = product.Gender;
                    departmentPicker.SelectedItem = product.Department;
                    product.Phone = int.Parse(phoneEntry.Text);
                    product.Email = emailEntry.Text;
                    product.Address = addressEditor.Text;
                    statusPicker.SelectedItem = product.Status;

                    var id = App.DbHelper.Addproduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ" + id, "ตกลง");

                }

                else
                {
                    product.Name = nameEntry.Text;
                    product.Lastname = lastnameEntry.Text;
                    product.Age = int.Parse(ageEntry.Text);
                    product.Gender = genderPicker.SelectedItem.ToString();
                    product.Department = departmentPicker.SelectedItem.ToString();
                    product.Phone = int.Parse(phoneEntry.Text);
                    product.Email = emailEntry.Text;
                    product.Status = statusPicker.SelectedItem.ToString();
                    product.Children = chlidLabel.ToString();
                    product.Address = addressEditor.Text;
                    product.Saraly = decimal.Parse(salaryLabel.Text);


                    var id = App.DbHelper.UpdateProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้า" + id, "ตกลง");
                }
                await Navigation.PopModalAsync();
            }
        }



        private void CancelButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
