using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using AppLicenseManager.Util;
using Telerik.Web;
using System.Security.Policy;

namespace AppLicenseManager
{
    public partial class Default : PageBase
    {
        #region Methods

        protected void ClearFields()
        {
            txtEmail.Text =
            txtPassword.Text = "";
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        protected bool dataValidation()
        {
            try
            {
                bool emailValidation = true;
                bool passwordValidation = true;

                if (string.IsNullOrEmpty(txtEmail.Text) || !IsValidEmail(txtEmail.Text)) //E-Mail Validation
                {
                    txtEmail.CssClass = "form-control is-invalid";
                    lblEmail.CssClass = "form-label is-invalid-label";
                    lblEmailInvalidFeedback.Visible = true;
                    lblEmailValidFeedback.Visible = false;
                    emailValidation = false;
                }
                else
                {
                    txtEmail.CssClass = "form-control is-valid";
                    lblEmail.CssClass = "form-label is-valid-label";
                    lblEmailValidFeedback.Visible = true;
                    lblEmailInvalidFeedback.Visible = false;
                }

                if (string.IsNullOrEmpty(txtPassword.Text)) //Password Validation
                {
                    txtPassword.CssClass = "form-control is-invalid";
                    lblPassword.CssClass = "form-label is-invalid-label";
                    lblPasswordInvalidFeedback.Visible = true;
                    lblPasswordValidFeedback.Visible = false;
                    passwordValidation = false;
                }
                else
                {
                    txtPassword.CssClass = "form-control is-valid";
                    lblPassword.CssClass = "form-label is-valid-label";
                    lblPasswordValidFeedback.Visible = true;
                    lblPasswordInvalidFeedback.Visible = false;
                }

                return emailValidation && passwordValidation;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected bool LoginValidation(string _email, string _password)
        {
            try
            {
                bool isValid = true;
                string email = _email;
                string password = CryptoEngine.Criptografar(_password, true);

                if (dataValidation())
                {
                    using (_ctx = new AppLicenseManager_Entities())
                    {
                        var queryLogin = (from objLogin in _ctx.tb_usuarios
                                          where objLogin.email == email
                                          && objLogin.senha == password
                                          && objLogin.cdStatusUsuario != 3
                                          select objLogin).FirstOrDefault();

                        if (queryLogin != null)
                        {
                            Session["Email"] = queryLogin.email;
                            Session["Password"] = queryLogin.senha;
                            Session["cdUsuario"] = queryLogin.cdUsuario;
                            Session["NomeUsuario"] = queryLogin.nomeUsuario;
                            Session["TipoUsuario"] = queryLogin.cdTipoUsuario;
                            Session["statusUsuario"] = queryLogin.cdStatusUsuario;
                        }
                        else
                        {
                            Session["Email"] =
                            Session["Password"] =
                            Session["cdUsuario"] =
                            Session["NomeUsuario"] =
                            Session["TipoUsuario"] =
                            Session["statusUsuario"] = "";
                            isValid = false;
                        }
                    }
                }
                return isValid;
            }
            catch (Exception ex)
            {
                Framework.Alerta("Error method: LoginValidation", "Error: " + ex.ToString(), "error");
                return false;
            }
        }

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Click
        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (LoginValidation(txtEmail.Text, txtPassword.Text))
            {
                Response.Redirect("../Default2.aspx");
            }
            else
            {
                ClearFields();
                Framework.Alerta("Error", "Invalid Credentials, Please Verify and Try Again", "error");
            }
        }
        #endregion
    }
}