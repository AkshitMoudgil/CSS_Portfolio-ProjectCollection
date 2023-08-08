

function successMessage(){
  alert("Success! Your action was completed successfully.");
}


function success(){
  alert("Success! Your action was completed successfully.");
}




document.addEventListener('DOMContentLoaded', function() {
  document.getElementById('success-link').addEventListener('click', function(event) {
    event.preventDefault(); // Prevent link from navigating to a new page
    alert("Nice Choice! Go for it..."); // Show success message
  });
});

document.addEventListener('DOMContentLoaded', function() {
  document.getElementById('success-link1').addEventListener('click', function(event) {
    event.preventDefault(); // Prevent link from navigating to a new page
    alert("Nice Choice! Go for it..."); // Show success message
  });
});

document.addEventListener('DOMContentLoaded', function() {
  document.getElementById('success-link2').addEventListener('click', function(event) {
    event.preventDefault(); // Prevent link from navigating to a new page
    alert("Nice Choice! Go for it..."); // Show success message
  });
});

document.addEventListener('DOMContentLoaded', function() {
  document.getElementById('subscribe').addEventListener('click', function(event) {
    event.preventDefault(); // Prevent link from navigating to a new page
    alert("Great! Now you will recieve our every update"); // Show success message
  });
});