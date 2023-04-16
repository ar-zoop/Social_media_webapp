<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" %>

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
								<h2 class="mu-heading-title">Share Post</h2>
							</div>

							<!-- Start Contact Content -->
							<div class="mu-contact-content">
								<div class="row">
                                <div class="col-md-3"></div>
								<div class="col-md-6">
									<div class="mu-contact-form-area">                                                     
                                            
                                           
											<INPUT id="oFile" type="file" runat="server" NAME="oFile">
                                            <asp:button id="btnUpload" class="mu-send-msg-btn"  type="submit" text="Upload" runat="server" OnClick="btnUpload_Click"></asp:button>
                                            <asp:Panel ID="frmConfirmation" Visible="False" Runat="server">
                                                <asp:Label id="lblUploadResult" Runat="server"></asp:Label>
                                            </asp:Panel>



                                            
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

