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
                        <div class="mu-pricing-area">
							<asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
					<asp:Repeater ID="R1" runat="server" >
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
                                            <%--<asp:HyperLink id="hyperlink1"  runat="server" NavigateUrl='display_profile.aspx?username=<%#Eval("username")%>' />--%>  <br />
                                            @<asp:LinkButton ID="LinkButton5" runat="server" Text='<%#Eval("username") %>' OnCommand="LinkButton5_Command1" CommandName='<%#Eval("username")%> '> </asp:LinkButton><br />
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image_file") %>' />  <br />
                                            <asp:HiddenField ID="h1" runat="server" Value='<%#Eval("post_id") %>' />
                                            <asp:LinkButton ID="like" class="mu-register-btn" runat="server" OnCommand="like_Command" CommandName='<%#Eval("post_id")%>'></asp:LinkButton>        
											<%--<asp:Button class="mu-register-btn" ID="like" runat="server" Text="Like" OnClick="like_Click"/>--%>
                                            <%--<asp:LinkButton ID="comment" CommandArgument='<%#Eval("post_id")%>' class="mu-register-btn" runat="server" text="Comment" OnCommand="comment_Click"> </asp:LinkButton>--%>
                                            <asp:LinkButton ID="comment2" CommandArgument='<%#Eval("post_id")%>' class="mu-register-btn" runat="server" text="Comment" OnCommand="comment2_Command"> </asp:LinkButton>

                                            <asp:Panel ID="show_delete_button" runat="server" Visible="false">
                                                <asp:LinkButton ID="delete" CommandArgument='<%# Eval("post_id") %>' class="mu-register-btn" runat="server" text="Delete" OnCommand="delete_Command" Visible="true"> </asp:LinkButton>        
                                            </asp:Panel>

                                           <br/> Likes=<asp:Label ID="likeCount" runat="server" Text='<%#Eval("likes") %>' ></asp:Label><br />
                                            
                                       
                                        <asp:Panel ID="show_comment_box" Visible="false" runat="server">
                                            <asp:TextBox ID="comment_box"  runat="server" class="form-control" placeholder="Comment here..."></asp:TextBox><br />
                                            <%--<asp:LinkButton ID="uploadComment" CommandArgument='<%# Eval("post_id") %>' class="mu-register-btn" runat="server" text="Post" OnCommand="uploadComment_Click"></asp:LinkButton>--%><br />
                                        </asp:Panel>

                                        <asp:Panel ID="display_comments" runat="server"  Visible="false">
                                            Comments: <br />
                                            <asp:Repeater ID="repeaterComments" runat="server">                                                
                                                <ItemTemplate>                                                    
                                                    @<asp:LinkButton ID="commentor" runat="server" Text='<%#Eval("username") %>' OnCommand="commentor_Command" CommandName='<%#Eval("username")%> '> </asp:LinkButton>  :                                           
                                                    <asp:Label ID="fetched_comment" runat="server"  Text='<%#Eval("comment") %>'></asp:Label>
                                                  <%--  <asp:HiddenField ID="h1" runat="server" Value='<%#Eval("post_id") %>' />--%>
                                                    <asp:Panel ID="show_delete_button" runat="server" Visible="false">
                                                        <asp:LinkButton ID="delete_comment" CommandArgument='<%# Eval("post_id") %>' class="mu-register-btn" runat="server" text="Delete" OnCommand="delete_comment_Command" Visible="true"> </asp:LinkButton>        
                                                    </asp:Panel>
                                                    <br/>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </asp:Panel>


                                        <%--<asp:TextBox ID="comment_box" Visible="false" runat="server" class="form-control" placeholder="Comment here..."></asp:TextBox>--%> <br />
                                        <%--<asp:LinkButton ID="uploadComment" CommandArgument='<%# Eval("post_id") %>' class="mu-send-msg-btn" runat="server" text="Post" OnCommand="uploadComment_Click"></asp:LinkButton>--%>        
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
                        <!-- End Contact Content -->
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- End Contact -->
</asp:Content>

