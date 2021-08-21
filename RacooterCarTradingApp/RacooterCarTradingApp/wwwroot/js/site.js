var App = function () {

    var handleSaveAnnouncement = function () {

        var obj = {
            AnnouncementId: $('#HiddenAnnouncementId').val(),
            Title: $('#Title').val(),
            Category: $('#Category').val(),
            Price: $('#Price').val(),
            Date: $('#Date').val(),
            Description: $('#Description').val(),
            Location: $('#Location').val(),
            PhoneNumber: $('#PhoneNumber').val()
        }
        if (obj.Title == undefined || obj.Title == "") {
            toastr.error('Title is required!');
            return false;
        }
        if (obj.Description == undefined || obj.Description == "") {
            toastr.error('Description is required!');
            return false;
        }

        if (obj.Price == undefined || obj.Price == "") {
            toastr.error('Price is required!');
            return false;
        }
        if (obj.Category == undefined || obj.Category == "" || obj.Category == "-1") {
            toastr.error('Category is required!');
            return false;
        }
        if (obj.Location == undefined || obj.Location == "") {
            toastr.error('Location is required!');
            return false;
        }        
        
        obj.Specification = {
            AnnouncementId: $('#HiddenAnnouncementId').val(),
            Make: $('#Make').val(),
            Model: $('#Model').val(),
            Year: $('#Year').val(),
            Mileage: $('#Mileage').val(),
            Power: $('#Power').val(),
            BodyType: $('#BodyType').val(),
            GetFuelType: $('#GetFuelType').val(),
            NrOfDoors: $('#NrOfDoors').val(),
            EngineSize: $('#EngineSize').val(),
            Emissions: $('#Emissions').val(),
            Color: $('#Color').val(),
            IsFullOptions: $('#IsFullOptions').val(),
            IsNegotiable: $('#IsNegotiable').val(),
            HasABS: $('#HasABS').is(':checked'),
            HasESP: $('#HasESP').is(':checked'),
            HasWarranty: $('#HasWarranty').is(':checked'),
            HasLogHistory: $('#HasLogHistory').is(':checked'),
            HasCruiseControl: $('#HasCruiseControl').is(':checked'),
            HasDualZoneClimate: $('#HasDualZoneClimate').is(':checked'),
            HasFullElectricWin: $('#HasFullElectricWin').is(':checked'),
            HasHeatedSeats: $('#HasHeatedSeats').is(':checked'),
            HasElectricMirrors: $('#HasElectricMirrors').is(':checked'),
            HasHeatedStWheel: $('#HasHeatedStWheel').is(':checked'),
            HasVentedSeats: $('#HasVentedSeats').is(':checked'),
            HadAccident: $('#HadAccident').is(':checked')
        }

        if (obj.Specification.Make == undefined || obj.Specification.Make == "") {
            toastr.error('Make is required!');
            return false;
        }
        if (obj.Specification.Model == undefined || obj.Specification.Model == "") {
            toastr.error('Model is required!');
            return false;
        }
        if (obj.Specification.Year == undefined || obj.Specification.Year == "") {
            toastr.error('Year is required!');
            return false;
        }
        if (obj.Specification.Mileage == undefined || obj.Specification.Mileage == "") {
            toastr.error('Mileage is required!');
            return false;
        }


        var imagesCount = 0;
        $('#ImagesContainerDiv').find('.each-image-uploaded').each(function () {
            
            var files = $(this).get(0).files[0];
            if (files != undefined && files != null) {
                imagesCount = imagesCount + 1;
            }
        });
        
        if (imagesCount == 0 && $('.each-already-uploaded-image').length <= 0) {
            toastr.error("Please attach image(s)")
            return false;
        }

        $.ajax({
            type: "POST",
            url: "/Announcements/AddUpdate",
            data: {
                data: obj
            },
            success: function (response) {
                
                App.SaveImages(response);
                toastr.success('Data Saved Successfully!');
                location.href = "/Announcements/Index";
            }
        })
    }

    let handleLoadCategories = () => {
        $.ajax({
            type: "GET",
            url: "/Announcements/_Categories",
            success: function (response) {
                $('#CategoriesContainer').html(response);
            }
        })
    }

    let handleSaveCategory = ($that) => {
        let $txtBox = $($that).parents('.form-group').find('#txtCategoryName');

        let name = $($txtBox).val();
        let id = $($txtBox).attr("data-id");

        if (name == undefined || name == "") {
            toastr.error("Please enter Category name");
            return false;
        }
        $($txtBox).val('');
        $.ajax({
            type: "POST",
            url: "/Announcements/SaveCategory",
            data: {
                id: id,
                name: name
            },
            success: function (response) {
                toastr.success("Category Saved Successfully!");
                App.LoadCategories();
            }
        })
    }

    let handleDeleteCategory = (id) => {
        $.ajax({
            type: "GET",
            url: "/Announcements/DeleteCategory",
            data: {
                id: id
            },
            success: function (response) {
                toastr.success("Category deleted successfully!")
                App.LoadCategories();
            }
        })
    }

    let handleMakeImageUploader = () => {
        let html = '<div class="col-md-3">';
        html += '<input type="file" class="each-image-uploaded" style="margin:5px;" />';
        html += '</div>';
        $('#ImagesContainerDiv').append(html)
    }

    let handleApproveAnnouncement = (AnnouncementId) => {
        $.ajax({
            type: "GET",
            url: "/Announcements/Approve",
            data: {
                Guid: AnnouncementId
            },
            success: function (response) {
                toastr.success("Announcement is approved!")
                location.href = '/Announcements/Index';
            }
        })
    }

    let handleLoadHomePageAnnouncements = ($that) => {
        

        let loaderHtml = '<div class="col-md-12"><h3 class="text-center alert alert-warning"> Please wait while loading data!!!</h3></div>';
        $('#AnnouncementsContainer').html(loaderHtml);
        var $parentDiv = $($that).parents('#FiltersContainerCollapse');

        var filterObj = {
            Title: $('#ftrTitle').val(),
            Category: $('#ftrCategory').val(),
            Price: $('#ftrPrice').val(),
            Model: $('#ftrModel').val(),
            Make: $('#ftrMake').val(),
            Year: $('#ftrYear').val(),
            Mileage: $('#ftrMileage').val(),
            Power: $('#ftrPower').val(),
            PageNumber: 1
        };

        $.ajax({
            type: "Get",
            url: "/Announcements/_Home",
            data: filterObj,
            success: function (response) {
                $('#AnnouncementsContainer').html(response);
            }
        })
    }

    let handleLoadUserMessages = (userId) => {
        
        $('.chat_list').removeClass('active_chat');
        $('div[data-id="' + userId + '"]').parents('.chat_list').addClass('active_chat');
        $('#selectedUserId').val(userId);
        $.ajax({
            type: "GET",
            url: "/Announcements/UserMessages",
            data: {
                userId: userId
            },
            success: function (response) {
                $('#UserMessagesContainer').html(response);
            }
        })
    }

    let handleSaveMessage = () => {        

        let msgTxt = $('#txtBoxMessage').val();
        if (msgTxt == "" || msgTxt.trim() == "" || msgTxt == undefined) {
            toastr.error("Please write a message first!");
            return false;
        }
        
        let receiverId = $('.active_chat').find('.chat_people').attr("data-id");

        $.ajax({
            type: "POST",
            url: "/Announcements/SaveMessage",
            data: {
                MessageText: msgTxt,
                receiverId: receiverId
            },
            success: function (response) {
                $('#txtBoxMessage').val("");
                App.LoadUserMessages(receiverId);                
            }
        })
    }


    let handleUpdateUser = () => {
        var obj = {
            id: $('#hiddenUserID').val(),
            FullName: $('#txtFullName').val(),
            IsBlockFromPost: $('#txtIsBlockFromPost').is(':checked'),
            IsReportedForBlock: $('#txtIsReportedForBlock').is(':checked')
        };

        if (obj.FullName == '') {
            toastr.error('Please enter FullName');
            return false;
        }

        $.ajax({
            type: "POST",
            url: "/Users/UpdateUser",
            data: {
                model: obj
            },
            success: function (response) {
                toastr.success("Data Save successfully!");
                location.href = '/Users/Index'
            }
        })
    }

    let handleSaveImages = (AnnouncementId) => {
        
        var formData = new FormData();

        formData.append("AnnouncementId", AnnouncementId);

        $('#ImagesContainerDiv').find('.each-image-uploaded').each(function () {
            formData.append("Images", $(this).get(0).files[0]);
        });

        $.ajax({
            type: "POST",
            contentType: false,
            processData: false,
            data: formData,
            url: "/Announcements/UploadImages",
            success: function (response) {

            }
        })
    }

    let handleSaveNewsPost = () => {
        let txtPostTitle = $('#txtPostTitle').val();
        let txtPostSubTitle = $('#txtPostSubTitle').val();
        let txtPostContent = $('#txtPostContent').val();

        if (txtPostTitle == "" || txtPostSubTitle == "" || txtPostContent == "") {
            toastr.error("Fields are required");
            return false;
        }

        let _hhtml = '<div class="col-md-12 text-center"><h4 class="alert alert-success"> Please wait while saving data</h4></div>';
        $('#NewsPostsFormContainer').append(_hhtml);

        $.ajax({
            type: "POST",
            url: "/Announcements/SaveNewsPost",
            data: {
                Title: txtPostTitle,
                SubTitle: txtPostSubTitle,
                Content: txtPostContent
            },
            success: function (response) {
                location.reload();
            }
        })
    }

    let handleReportSeller = (userIdToReport) => {
        $.ajax({
            type: "GET",
            url: "/Announcements/ReportUser",
            data: {
                UserIdToReport: userIdToReport
            },
            success: function (response) {
                toastr.success("User Reported Successfully");
            }
        })
    }

    return {
        SaveAnnouncement: function () {
            handleSaveAnnouncement();
        },
        LoadCategories: function () {
            handleLoadCategories();
        },
        SaveCategory: function ($that) {
            handleSaveCategory($that)
        },
        DeleteCategory: function (id) {
            handleDeleteCategory(id);
        },
        MakeImageUploader: function () {
            handleMakeImageUploader();
        },
        ApproveAnnouncement: function (AnnouncementId) {
            handleApproveAnnouncement(AnnouncementId);
        },
        LoadHomePageAnnouncements: function ($that) {
            handleLoadHomePageAnnouncements($that);
        },
        LoadUserMessages: function ($that) {
            handleLoadUserMessages($that);
        },
        SaveMessage: function () {
            handleSaveMessage();
        },
        UpdateUser: function () {
            handleUpdateUser();
        },
        SaveImages: function (AnnouncementId) {
            handleSaveImages(AnnouncementId);
        },
        SaveNewsPost: function () {
            handleSaveNewsPost();
        },
        ReportSeller: function (userIdToReport) {
            handleReportSeller(userIdToReport);
        }
    }
}();