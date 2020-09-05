
$(document).ready(function () {

 //for each worker object create adn insert a div into .owl-carousl
    //call owlshit to initate the carouslel.

   //OwlShit();  //                         
    GetData();
    $(".owl-carousel").on('click', '.item', function () {
        alert("hi");
        GetDataModal(this);
        var id = $(this).find('input').val();
        alert(id.toString());

    });
    
})
//functions
function OwlShit()
{
    alert("owl shit");
    var owl = $(".owl-carousel");
    owl.owlCarousel({
        items: 4,
        loop: true,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 1000,
        autoplayHoverPause: true
    });
    $('.play').on('click', function () {
        owl.trigger('play.owl.autoplay', [1000])
    });
    $('.stop').on('click', function () {
        owl.trigger('stop.owl.autoplay')
    });
}
function GetData() {
    var workercount = 0;
    alert("hi");
    $.ajax({
        url: 'api/Values',
        type: 'GET',
        cache:false,
        

        success: function (data, textStatus, xhr) {

            
            alert(data+"1");
            
            $.each(data, function (index, value) {
                workercount = index;
                var data = $.parseJSON(value);
                $(".owl-carousel").append("<div class='item'>" + "<p>" + data.FirstName + "</p>" + "<p>" + data.LastName + "</p>" + "<p>" + data.Email + "</p>" + "<p>" + data.Password + "</p>" +
                    "<input id='worker_id' name='worker_id' type='hidden' value='"+data.Id+"'>"+"</div>");
            })
            alert("owl shit 2");
            var owl = $(".owl-carousel");
            owl.owlCarousel({
                items: workercount-1,
                loop: true,
                margin: 10,
                autoplay: true,
                autoplayTimeout: 1000,
                autoplayHoverPause: true,
                callbacks: true,
                onInitialized: message


            });
       
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr);
            console.log(textStatus);
            console.log(errorThrown);
            console.log('Error in Operation');
            alert(textStatus.toString());
            alert(xhr);
            alert("error" + errorThrown.toString());
        }
    });
}
function message() {
   
    alert("hi from initialized 3");
}
function slider_div_onClick()
{
    alert("hi");
}
function GetDataModal(div)
{
    alert(div);
   /* $("#modalUpdateDelete").find("FirstName").text() = $(div).find("FirstName").text();*/
   /* $("#modalUpdateDelete").modal('show');*/

}

   