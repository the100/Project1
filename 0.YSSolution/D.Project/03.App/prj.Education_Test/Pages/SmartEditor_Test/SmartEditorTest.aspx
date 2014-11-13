<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmartEditorTest.aspx.cs" Inherits="Pages_SmartEditor_Test_SmartEditorTest" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script type="text/javascript" src="/Common/js/HuskyEZCreator.js" charset="utf-8"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="ir2" runat="server" ClientIDMode="Static" Rows="10" Columns="100" TextMode="MultiLine"></asp:TextBox>
        <asp:HiddenField ID="hdtext" runat="server" ClientIDMode="Static" />
        <%--<textarea name="ir1" id="ir1" rows="10" cols="100">에디터에 기본으로 삽입할 글(수정 모드)이 없다면 이 value 값을 지정하지 않으시면 됩니다.</textarea>--%>
        <asp:Button ID="btnTest" runat="server" OnClientClick="submitContents(this)" OnClick="btnTest_Click"  ClientIDMode="Static"/>
    </div>

        <script type="text/javascript">

            var oEditors = [];

            nhn.husky.EZCreator.createInIFrame({

                oAppRef: oEditors,

                elPlaceHolder: "ir2",

                sSkinURI: "/Pages/SmartEditor_Test/SmartEditor2Skin.html",

                fCreator: "createSEditor2"

            });


            function submitContents(elClickedObj) {
                oEditors.getById["ir2"].exec("UPDATE_CONTENTS_FIELD", []);	// 에디터의 내용이 textarea에 적용됩니다.

                // 에디터의 내용에 대한 값 검증은 이곳에서 document.getElementById("ir1").value를 이용해서 처리하면 됩니다.

                //var value = document.getElementById("ir2").value;
                //document.getElementById("ir2").value = encodeURIComponent(value);
                //document.getElementById("hdtext").value = value;

                try {
                    //elClickedObj.form.submit();
                } catch (e) { }
            }


    </script>
        <asp:Literal ID="ltrTest" runat="server" />
    </form>
</body>
</html>
