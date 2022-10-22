$(document).ready(function () {
		$("#btnSave").click(function () {
			SaveItem();
		});
	});

	function SaveItem() {
		var formData = new FormData();
		formData.append("CategoryId", $("#CategoryId").val());
		formData.append("ItemCode", $("#ItemCode").val());
		formData.append("ItemName", $("#ItemName").val());
		formData.append("ItemPrice", $("#ItemPrice").val());
		formData.append("Description", $("#Description").val());
		formData.append("ImagePath", $("#ImagePath").get(0).files[0]);

		$.ajax({
			async: true,
			dataType: 'JSON',
			type: 'POST',
			contentType: false,
			processorType: false,
			URL: '/Item/Index',
			dats: formData,
			success: function (data) {
				alert(data);
				Reset();
			},
			error: function () {
				alert('Error!!');
			}
		});
	}

	function Reset() {
		$("#CategoryId").val("");
		$("#ItemCode").val("");
		$("#ItemName").val("");
		$("#ItemPrice").val("");
		$("#Description").val("");
		$("#ImagePath").val("");
	}