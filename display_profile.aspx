<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="display_profile.aspx.cs" Inherits="display_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Start Contact -->
    <section id="mu-contact">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="mu-contact-area">

                        <div class="mu-title-area">
                            <h2 class="mu-heading-title">Profile</h2>
                        </div>

                        <!-- Start Contact Content -->
                        <div class="mu-contact-content">
                            <div class="row">
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <div class="mu-contact-form-area">
                                        <div id="form-messages"></div>

                                        <div class="form-group">
                                            Name:
                                            <asp:Label ID="name" runat="server" Text="Name"></asp:Label>

                                        </div>
                                        <div class="form-group">
                                            Username:
                                            <asp:Label ID="username" runat="server" Text="Username"></asp:Label>

                                        </div>
                                        <div class="form-group">
                                            Email:
                                            <asp:Label ID="email" runat="server" Text="Email"></asp:Label>


                                        </div>
                                        <div class="form-group">
                                            Bio:
                                            <asp:Label ID="bio" runat="server" Text="Bio"></asp:Label>


                                        </div>
                                        <div class="form-group">
                                            Contact Number:
                                            <asp:Label ID="contact_number" runat="server" Text="Contact Number"></asp:Label>


                                        </div>
                                        <%--button--%>
                                        <asp:LinkButton ID="followId" class="mu-register-btn" runat="server" OnCommand="followId_Click" Text="Follow"></asp:LinkButton>

                                        <%--repeater--%>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- End Contact Content -->
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- End Contact -->
</asp:Content>

