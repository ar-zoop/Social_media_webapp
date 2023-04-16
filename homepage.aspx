<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
		<!-- Start Pricing  -->
		<section id="mu-pricing">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<div class="mu-pricing-area">
							
						
					<asp:Repeater ID="R1" runat="server">
                        <ItemTemplate>
							<!-- Start repeater here -->
							<div class="mu-pricing-conten">
                                <div class="container">
								<div class="row">
									
                                   <div class="col-md-3 ">   
                                   </div>
                               
									<div class="col-md-6 ">                                        
										<div class="mu-single-price">
                                            <asp:HyperLink id="hyperlink1" Text='<%#Eval("username") %>' runat="server" NavigateUrl='display_profile.aspx?username=hyperlink1.Text' />  <br />
                                            <asp:Image ID="imgDisplay" runat="server" />  <br />
											<asp:Button class="mu-register-btn" ID="like" runat="server" Text="Like" OnClick='like_Click'  />
                                            <asp:Button class="mu-register-btn" ID="comment" runat="server" Text="Comment"  />
                                            <asp:Button class="mu-register-btn" ID="share" runat="server" Text="Share" /> <br />
                                            Likes=<asp:Label ID="likeCount" runat="server" Text='<%#Eval("likes") %>' ></asp:Label>
                                        </div>
                                        
                                        
									</div>

									
								</div>
                                </div>
							</div>

                            <!-- End repeater here -->
                        </ItemTemplate>
                     </asp:Repeater>

						</div>
					</div>
				</div>
			</div>
		</section>
		<!-- End Pricing -->

		

	

</asp:Content>

