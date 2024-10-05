<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppLicenseManager.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html>
<head runat="server">

    <%-- Google Font - Afacad Flux --%>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Afacad+Flux:wght@100..1000&display=swap" rel="stylesheet">

    <%-- Bootstrap CSS--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">

    <%-- Bootstrap Icons CSS --%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">

    <%-- Font Awesome --%>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.6.0/css/all.min.css" rel="stylesheet" />

    <%-- Internal CSS --%>
    <link href="Util/Default.css" rel="stylesheet" />

    <%-- Bootstrap Js--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

    <%-- Sweet Alert Js--%>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.12.4/dist/sweetalert2.all.min.js"></script>

    <%-- Alerta --%>
    <script src="Util/Alerta.js"></script>

    <title>ALM - Login</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel ID="pnlLogin" runat="server">

            <header id="login-header">
                <h1>App License Manager</h1>

                <p>Enter with your credentials</p>
            </header>

            <main class="login-content my-3">

                <div class="user-data form-floating">
                    <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="E-mail" TextMode="Email" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblLogin" runat="server" AssociatedControlID="txtEmail" CssClass="form-label">
                                <span class="login-icon"><i class="fa-solid fa-user"></i></span>
                                <span class="login-text">E-mail</span>
                    </asp:Label>
                </div>

                <div class="user-data form-floating my-3">
                    <asp:TextBox ID="txtPassword" runat="server" PlaceHolder="Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="form-label">
                            <span class="login-icon"><i class="fa-solid fa-lock"></i></span>
                            <span class="login-text">Password</span>
                    </asp:Label>
                </div>

                <div class="mt-3">
                    <asp:Button ID="btn_login" runat="server" Text="Autenticate" />
                </div>

            </main>

        </asp:Panel>

    </form>
</body>
</html>
