const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
var container = document.getElementById('container');
 
function OpenOtherDiv(tip) {
	console.log(tip);
	if (tip == 'leftPanel') { 
		$("#container").addClass("right-panel-active"); 
	} else if (tip == 'rightPanel') {  
		$("#container").removeClass("right-panel-active");
	}

}