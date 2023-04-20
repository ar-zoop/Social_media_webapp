<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="Homepage" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
		<!-- Start Pricing  -->
		<section id="mu-pricing">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<div class="mu-pricing-area">
							<asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
					<asp:Repeater ID="R1" runat="server">
                        <ItemTemplate>
							<!-- Start repeater here -->
						<asp:UpdatePanel ID="up" runat="server">
                            <ContentTemplate>
			
                            				<div class="mu-pricing-conten">
                                <div class="container">
								<div class="row">
									
                                   <div class="col-md-3 ">   
                                   </div>
                               
									<div class="col-md-6 ">                                        
										<div class="mu-single-price">
                                            <%--@<asp:HyperLink id="hyperlink1"  runat="server" NavigateUrl='display_profile.aspx?username=<%#Eval("username")%>' />  <br />--%>
                                            @<asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Eval("username") %>' OnCommand="LinkButton1_Click" CommandName='<%#Eval("username")%> '> 
                                               
                                            </asp:LinkButton><br />
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image_file") %>' />  <br />
                                            <asp:HiddenField ID="h1" runat="server" Value='<%#Eval("post_id") %>' />
                                            <asp:LinkButton ID="like" class="mu-register-btn" runat="server" Text="Like" OnCommand="LinkButton2_Click" CommandName='<%#Eval("post_id")%>'></asp:LinkButton>        
											<%--<asp:Button class="mu-register-btn" ID="like" runat="server" Text="Like" OnClick="like_Click"/>--%>
                                            <asp:Button class="mu-register-btn" ID="comment" runat="server" Text="Comment"  />
                                            <asp:Button class="mu-register-btn" ID="share" runat="server" Text="Share" /> <br />
                                            Likes=<asp:Label ID="likeCount" runat="server" Text='<%#Eval("likes") %>' ></asp:Label>
                                        </div>
                                        
                                        
									</div>

									
								</div>
                                </div>
							</div>

                            <!-- End repeater here -->
                                </ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="like" EventName="Command" />
</Triggers>
                            </asp:UpdatePanel>
			
                                            </ItemTemplate>
                     </asp:Repeater>
            			</div>
					</div>
				</div>
			</div>
		</section>
		<!-- End Pricing -->

		

	

</asp:Content>

