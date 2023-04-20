<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="my_profile.aspx.cs" Inherits="profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Start Contact -->
		<section id="mu-contact">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<div class="mu-contact-area">

							<div class="mu-title-area">
								<h2 class="mu-heading-title">My Profile</h2>
							</div>

							<!-- Start Contact Content -->
							<div class="mu-contact-content">
								<div class="row">
                                <div class="col-md-3"></div>
								<div class="col-md-6">
									<div class="mu-contact-form-area">
										<div id="form-messages"></div>
											    <asp:Panel ID="frmConfirmation" Visible="False" Runat="server">
                                                    <asp:Label id="UpdateResult" Runat="server"></asp:Label>
                                                </asp:Panel>
												<div class="form-group">                
													
                                                    Name: <asp:TextBox ID="name" class="form-control" placeholder="Name" runat="server"></asp:TextBox>
												</div>
                                                <div class="form-group">  
                                                    Username: 
                                                    <asp:Label ID="username" runat="server" Text="Username"></asp:Label>
													
												</div>
												<div class="form-group">                
                                                    Email: <asp:TextBox ID="email" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                                                    
												</div>              
												<div class="form-group">
                                                    Bio: <asp:TextBox ID="bio" runat="server" class="form-control" placeholder="Bio"></asp:TextBox>
													
												</div>
                                                <div class="form-group">              
                                                    Contact Number: <asp:TextBox ID="contact_number" runat="server" class="form-control" placeholder="Contact Number"></asp:TextBox>  
													
												</div> 
												
                                                <asp:Button ID="Button1" class="mu-send-msg-btn" runat="server" Text="UPDATE" OnClick="Button1_Click" />
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

