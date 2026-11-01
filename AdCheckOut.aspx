<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdCheckOut.aspx.cs" Inherits="The18th.AdCheckOut" %>


 <%-- <script src="https://www.paypal.com/sdk/js?client-id=YOUR_CLIENT_ID"></script>--%>

    
 <script src="https://www.paypal.com/sdk/js?client-id=AQ6A6kHw_EF3gLPT3gTCHbN5t-eJr-4UWFZt6-aTsfBRS6QNAzpIDnF-o1DMZ6GsLq-0okjbJnLgjIv2"></script>
        
    
<br /><br /><br /><br /><br />

<center>
<!DOCTYPE html>
<html>
  <head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
           
     
            <script type="text/javascript">


                var myGlobalAmount = 199.00;

                window.onload = function getAmount() {

                    if (document.cookie.length != 0) {

                        var nameValueArray = document.cookie.split("=");
                        alert("Name = " + nameValueArray[0] + "Value =" + nameValueArray[1]);

                        var myAmount = parseFloat(nameValueArray[1].value);

                        return myAmount;
                    }

                    else
                                              

                }


                var myGlobalAmount = myAmount;

              
            </script>


  </head>
  <body>
    <!-- Replace "test" with your own sandbox Business account app client ID -->
    <%--<script src="https://www.paypal.com/sdk/js?client-id=test&currency=USD"></script>--%>

    <script src="https://www.paypal.com/sdk/js?client-id=AQ6A6kHw_EF3gLPT3gTCHbN5t-eJr-4UWFZt6-aTsfBRS6QNAzpIDnF-o1DMZ6GsLq-0okjbJnLgjIv2"></script>

    <!-- Set up a container element for the button -->
    <div id="paypal-button-container"></div>
    <script>
              
        window.onload = function payMe() {

            paypal.Buttons({
                // Sets up the transaction when a payment button is clicked
                createOrder: (data, actions) => {
                    return actions.order.create({
                        purchase_units: [{
                            amount: {

                               
                                value: '199.00'// Can also reference a variable or function
                            }
                        }]
                    });
                },
                // Finalize the transaction after payer approval
                onApprove: (data, actions) => {
                    return actions.order.capture().then(function (orderData) {
                        // Successful capture! For dev/demo purposes:
                        console.log('Capture result', orderData, JSON.stringify(orderData, null, 2));
                        const transaction = orderData.purchase_units[0].payments.captures[0];
                        /*alert(`Transaction ${transaction.status}: ${transaction.id}\n\nSee console for all available details`);*/
                        // When ready to go live, remove the alert and show a success message within this page. For example:
                        // const element = document.getElementById('paypal-button-container');
                        // element.innerHTML = '<h3>Thank you for your payment!</h3>';
                        // Or go to another URL:  actions.redirect('thank_you.html');

                        actions.redirect('AdConfirmation.aspx');

                    });
                }
            }).render('#paypal-button-container');


        }

    </script>
  </body>
</html>

</center>


<br /><br /><br />

