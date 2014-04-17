viewModel = {
    lookupCollection: ko.observableArray()
};

$(document).ready(function () {
    
    $.ajax({
        url: '/Social/GetData',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $(data).each(function (index, element) {
                var mappedItem =
                    {
                        ProductID: ko.observable(element.ProductID),
                        Name: ko.observable(element.Name),
                        Category: ko.observable(element.Category),
                        Price: ko.observable(element.Price),
                        Mode: ko.observable("display"),
                        imgUrl: ko.observable(element.imgUrl)
                    };
                viewModel.lookupCollection.push(mappedItem);
            });
            ko.applyBindings(viewModel);
        },
        error: function () {
            alert("Error fetching data");
        }
    });
});


$(document).on("click", ".kout-edit", null, function () {
    debugger;
    var current = ko.dataFor(this);
    current.Mode("edit");
});

$(document).on("click", ".kout-cancel", null, function () {
    var current = ko.dataFor(this);
    current.Mode("display");
});

$(document).on("click", ".kout-update", null, function () {
    var current = ko.dataFor(this);
    saveData(current);
    current.Mode("display");

});

$(document).on("click", "#btnCreate", null, function () {
    var newData = {
        ProductID: ko.observable(0),
        Name: ko.observable(),
        Category: ko.observable(),
        Price: ko.observable(),
        Mode: ko.observable("edit"),
        imgUrl: ko.observable("../Images/Jellyfish.jpg")
    };
    viewModel.lookupCollection.push(newData);
});

$(document).on("click", ".kout-delete", null, function () {
    var current = ko.dataFor(this);
    deleteData(current.ProductID());
});

function saveData(current) {
    var postUrl = "";
    var submitData = {
        ProductID: current.ProductID(),
        Name: current.Name(),
        Category: current.Category(),
        Price: current.Price(),
        imgUrl: current.imgUrl()
    };
    if (current.ProductID == 0) {
        postUrl = "/Social/Save";
    }
    else {
        postUrl = "/Social/Create";
    }
    $.ajax({
        url: postUrl,
        type: 'POST',
        data: JSON.stringify(submitData),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            current.ProductID(data);
            maxid = 0;
        },
        error: function () {
            alert("Unable to save data");
        }
    });
}

function deleteData(productid) {
    var postUrl = "/Social/Delete";
    var submitData = { id: productid };
    $.ajax({
        url: postUrl,
        type: 'POST',
        data: JSON.stringify(submitData),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            viewModel.lookupCollection.removeAll();
            $(data).each(function (index, element) {
                var mappedItem =
                    {
                        ProductID: ko.observable(element.ProductID),
                        Name: ko.observable(element.Name),
                        Category: ko.observable(element.Category),
                        Price: ko.observable(element.Price),
                        Mode: ko.observable("display"),
                        imgUrl: ko.observable(element.imgUrl)
                    };
                viewModel.lookupCollection.push(mappedItem);
            });

        },
        error: function () {
            alert("Unable to delete data");
        }
    });
}
