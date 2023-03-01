// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const main = async () => {
        var url = '/api/Customer';
    var reponse = await fetch(url);
    var data = await reponse.json();
    renderSlide(data);
}
    const renderSlide = (data) => {
        var domSlide = document.querySelector("#bodyContent")
    var html = '';
        data.forEach((element, index) => {
            var birthday = new Date(Date.parse(element.birthday));
            var date = new Date(Date.parse(element.date));
            var birthdayString = [birthday.getDate(), birthday.getMonth() + 1, birthday.getFullYear()].join('/');
            var dateString = [date.getDate(), date.getMonth() + 1, date.getFullYear()].join('/');
        html += `
                <tr>
                  <th scope="row">${element.id}</th>
                  <td>${element.fullName}</td>
                  <td>${birthdayString}</td>
                  <td>${dateString}</td>
                <td>${element.phone}</td>
                <td>${element.address}</td>
                <td>${element.email}</td>

                  <td>
                              <button type="button" class="btn btn-warning" onclick='renderUpdate(${JSON.stringify(element)})'>
                        Edit
                    </button>
                        <button type="button" class="btn btn-danger" onclick='Delete(${element.id})'>
                        Delete
                    </button>
                  </td>
                </tr>
                `;
        });
    domSlide.innerHTML = html;
     }
     
    const  renderUpdate=(data)=>{
        let html=`
    <div class="modal" id="modalUpdate">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Edit TypeClothes</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <!-- Modal body -->
                <div class="modal-body">
                    <div class="form-group">
                        <div class="mb-3 mt-3">
                            <label for="txtid" class="form-label">ID : </label>
                            <input type="text" class="form-control" value="${data.id}" id="txtid" name="txtid" readonly>
                        </div>
                        <div class="mb-3 mt-3">
                            <label for="txtname_update" class="form-label">Name : </label>
                            <input type="text" class="form-control" value="${data.fullName}" id="txtname_update" placeholder="Enter name" name="txtname_update" required>
                        </div>
                        <div class="mb-3">
                            <label for="txtlimit_update" class="form-label">Limit : </label>
                            <input type="number" class="form-control" value="${data.limit}" id="txtlimit_update" placeholder="Enter limit" name="txtlimit_update" required>
                        </div>
                        <td>
                            <button type="button" class="btn btn-primary" onclick="Update()">Submit</button>
                    </div>
                </div>
            </div>
        </div>
    </div>`;
    document.querySelector("#renderUpdate").innerHTML=html;
    console.log(html);
    $('#modalUpdate').modal('show')
    }
    const Add = async () => {
        let fullName = document.querySelector("#txtname").value;
        let birthday = document.querySelector("#txtbirthday").value;
        let phone = document.querySelector("#txtphone").value;
        let address = document.querySelector("#txtaddress").value;
        let email = document.querySelector("#txtemail").value;
        var birth = new Date(birthday);


    let dataSend = {
        fullName: fullName,
        birthday: birth,
        date: birth,
        phone: phone,
        address: address,
        email:email
        };
        console.log(dataSend);
    let response = await fetch("/api/Customer", {
        method: "POST",
    body: JSON.stringify(dataSend),
    headers: {
        'Content-Type': 'application/json',
    'Accept': 'application/json'
                }
            }).then(rs => {
                if (rs.status == 200) {
        alert("Thêm thành công!!!");
    main()
                } else {
        alert("Thêm thất bại")
    }
            })
    }
    const Delete = async (id) => {
        let response = await fetch("/api/Customer?id=" + id,{
        method: "DELETE",
        }).then(rs => {
            if (rs.status == 200) {
        alert("Xóa thành công!!!");
    main()
            } else {
        alert("Xóa thất bại")
    }
        })
    }
    const Update = async () => {
        let id = document.querySelector("#txtid").value;
    let name = document.querySelector("#txtname_update").value;
    let limit = document.querySelector("#txtlimit_update").value;
    let dataSend = {
        name: name,
    limit: limit
        };
    let response = await fetch("/api/Customer?id=" + id, {
        method: "PUT",
    body: JSON.stringify(dataSend),
    headers: {
        'Content-Type': 'application/json',
    'Accept': 'application/json'
            }
        }).then(rs => {
            if (rs.status == 200) {
        alert("Chỉnh sửa thành công!!!");
    main()
            } else {
        alert("Chỉnh sửa thất bại thất bại")
    }
        })
    }
    main()