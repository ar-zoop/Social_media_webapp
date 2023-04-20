
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>


    <!-- Favicon -->
    <link rel="shortcut icon" type="image/icon" href="assets/images/favicon.ico" />
    <!-- Font Awesome -->
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet"/>
    <!-- Bootstrap -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Slick slider -->
    <link href="assets/css/slick.css" rel="stylesheet"/>
    <!-- Theme color -->
    <link id="switcher" href="assets/css/theme-color/default-theme.css" rel="stylesheet"/>

    <!-- Main Style -->
    <link href="style.css" rel="stylesheet"/>

    <!-- Fonts -->    
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,400i,600,700,800" rel="stylesheet"/>     
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet"/>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <!-- Start Contact -->
		<section id="mu-contact">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<div class="mu-contact-area">
                            <asp:Button ID="Button2" runat="server" Text="Register" OnClick="Button2_Click" />
							<div class="mu-title-area">
								<h2 class="mu-heading-title">Login for Instagram</h2>
							</div>

							<!-- Start Contact Content -->
							<div class="mu-contact-content">
								<div class="row">
                                <div class="col-md-3"></div>
								<div class="col-md-6">
									<div class="mu-contact-form-area">
										<div id="form-messages"></div>
											
												
                                                <div class="form-group">  
                                                     
                                                    <asp:TextBox ID="username" runat="server" class="form-control" placeholder="Username"></asp:TextBox>
													
												</div>
											        
												
                                                <div class="form-group">              
                                                    <asp:TextBox ID="password" runat="server" class="form-control" placeholder="Password"></asp:TextBox>  
													
												</div> 
                                                <asp:Button ID="Button1" class="mu-send-msg-btn" runat="server" Text="LOGIN" OnClick="Button1_Click" />
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
    </div>
    </form>
    <!-- Start footer -->
    <footer id="mu-footer" role="contentinfo">
        <div class="container">
            <div class="mu-footer-area">
                <div class="mu-footer-bottom">
                    <p class="mu-copy-right">&copy; Copyright arzoo-bapna
                        All right reserved.</p>
                </div>
            </div>
        </div>

    </footer>
    <!-- End footer -->
      <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <!-- Bootstrap -->
    <script src="assets/js/bootstrap.min.js"></script>
    <!-- Slick slider -->
    <script type="text/javascript" src="assets/js/slick.min.js"></script>
    <!-- Event Counter -->
    <script type="text/javascript" src="assets/js/jquery.countdown.min.js"></script>
    <!-- Ajax contact form  -->
    <script type="text/javascript" src="assets/js/app.js"></script>



    <!-- Custom js -->
    <script type="text/javascript" src="assets/js/custom.js"></script>

</body>
</html>
