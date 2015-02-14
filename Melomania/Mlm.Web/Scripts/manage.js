; jQuery(document).ready(function () {
    var control = document.getElementById("file_img");
    //control.onchange = function (event) {
    //    var i = 0,
    //        files = control.files,
    //        len = file[0].length;

    //    for (; i < len; i++) {
    //        console.log("Filename: " + files[i].name);
    //        console.log("Type: " + files[i].type);
    //        console.log("Size: " + files[i].size + " bytes");
    //    }
    //    reader.readAsDataURL(control.files[0])
    //}
    control.addEventListener("change", function (event) {
        var i = 0,
            files = control.files,
            len = files[0].length;

        for (; i < len; i++) {
            console.log("Filename: " + files[i].name);
            console.log("Type: " + files[i].type);
            console.log("Size: " + files[i].size + " bytes");
        }
        reader.readAsDataURL(control.files[0])
    }, false);

    var reader = new FileReader();
    reader.onload = function (event) {
        var dataUri = event.target.result,
            img = document.getElementById("new_image");

        img.src = dataUri;
    };

    reader.onerror = function (event) {
        console.log("File error: " + event.target.error.code);
    };

    $(".close").on("click", function () {
        $(".message").css("display", "none");
    });
});



