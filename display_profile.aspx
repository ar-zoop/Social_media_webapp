<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="display_profile.aspx.cs" Inherits="display_profile" %>

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
													Name: <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                                                    
												</div>
                                                <div class="form-group">  
                                                    Username: <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
													
												</div>
												<div class="form-group">    
                                                    Email: <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>            
                                                  
                                                    
												</div>              
												<div class="form-group">
                                                    Bio: <asp:Label ID="Label4" runat="server" Text="Bio"></asp:Label>
                                                    
													
												</div>
                                                <div class="form-group">   
                                                    Contact Number: <asp:Label ID="Label5" runat="server" Text="Contact Number"></asp:Label>           
                                                    
													
												</div> 
												
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

