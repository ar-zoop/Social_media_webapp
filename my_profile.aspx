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
                                <div class="col-md-2"></div>
								<div class="col-md-8">
									<div class="mu-contact-form-area">
										<div id="form-messages"></div>
											  
												<div class="form-group">                
                                                    <asp:LinkButton ID="LinkButton1" class="mu-register-btn" runat="server" OnCommand="LinkButton1_Command" Text="Followers"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" class="mu-register-btn" runat="server" OnCommand="LinkButton2_Command" Text="Following"></asp:LinkButton>
                                                    <br />
                                                    <asp:Panel ID="followersPanel" runat="server" Visible="false">
                                                        Total followers:
                                                        <asp:Label ID="followersCount" runat="server"></asp:Label>
                                                        <asp:Panel ID="repeaterPanel" runat="server" Visible="false">
                                                            <asp:Repeater ID="followersRepeater" runat="server">
                                                                <ItemTemplate>
                                                                    @<asp:LinkButton ID="LinkButton3" runat="server" Text='<%#Eval("follower_name") %>' OnCommand="LinkButton3_Command" CommandName='<%#Eval("username")%> '> </asp:LinkButton><br />
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </asp:Panel>

                                                    </asp:Panel>

                                                    <asp:Panel ID="followingPanel" runat="server" Visible="false">
                                                        Total following:
                                                        <asp:Label ID="followingCount" runat="server"></asp:Label>
                                                        <asp:Panel ID="repeaterPanel1" runat="server" Visible="false">
                                                            <asp:Repeater ID="followingRepeater" runat="server">
                                                                <ItemTemplate>
                                                                    @<asp:LinkButton ID="LinkButton4" runat="server" Text='<%#Eval("username") %>' OnCommand="LinkButton4_Command1" CommandName='<%#Eval("username")%> '> </asp:LinkButton><br />
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </asp:Panel>

                                                    </asp:Panel>
                                                    <%--<asp:TextBox ID="name" class="form-control" placeholder="Name" runat="server"></asp:TextBox>--%>
                                                    Name: <asp:TextBox ID="name" class="form-control" runat="server"></asp:TextBox>
												</div>
                                                <div class="form-group">  
                                                    Username: 
                                                    <asp:Label ID="username" runat="server" Text="Username"></asp:Label>
                                                    
												</div>
												<div class="form-group">                
                                                    Email: <asp:TextBox ID="email" runat="server" class="form-control"></asp:TextBox>
                                                    
												</div>              
												<div class="form-group">
                                                    Bio: <asp:TextBox ID="bio" runat="server" class="form-control"></asp:TextBox>
													
												</div>
                                                <div class="form-group">              
                                                    Contact Number: <asp:TextBox ID="contact_number" runat="server" class="form-control"></asp:TextBox>  
													
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

