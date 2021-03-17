using Rentoolo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rentoolo.DoniyorJN
{
    public partial class AddNewsDoniyorJN : BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Model.NewsDoniyorJN item = new Model.NewsDoniyorJN();

            try
            {
                var publishDate = DateTime.ParseExact(TextBoxDate.Text, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);

                publishDate = publishDate.AddHours(DateTime.Now.Hour);
                publishDate = publishDate.AddMinutes(DateTime.Now.Minute);
                publishDate = publishDate.AddSeconds(DateTime.Now.Second);

                item.Date = publishDate;
                item.Text = NewsText.Text;
                item.CreatedDate = DateTime.Now;
                item.AuthorId = User.UserId;
                item.Active = CheckBoxActive.Checked;

                DataHelperDoniyorJN.AddNews(item);
            }
            catch (System.Exception ex)
            {
                DataHelper.AddException(ex);
            }

            Response.Redirect("NewsDoniyorJN.aspx");
        }
    }
}