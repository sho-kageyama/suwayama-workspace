<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>ユーザー情報登録</title>
<meta charset="UTF-8">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<!-- jQueryの読み込み -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script type="text/javascript">
<!--
	window.document.onkeypress = lineCheck;
	function lineCheck(e) {
		var ta = document.getElementById("facility-info-remarks");
		var row = ta.getAttribute("rows");
		var r = (ta.value.split("\n")).length;
		if (document.all) {
			if (r >= row && window.event.keyCode == 13) { //keyCode for IE
				return false; //入力キーを無視
			}
		} else {
			if (r >= row && e.which == 13) { //which for NN
				return false;
			}
		}
	}
//-->
</script>
</head>
<body>
	<div id="base">
		<jsp:include page="/WEB-INF/views/header/header.jsp" flush="true" />
		<div id="contents">
			<div id="view-title">ユーザー情報管理</div>

			<form:errors path="errors" />
			

			<form:form modelAttribute="userFormSession" action="/user/confilm"
				method="post">

				<p id="contents-title">ユーザー情報を入力してください</p>
				<table id="facility-info">
					<tr>
						<th class="facility-info-th">ユーザー名</th>
						<td>
						<a class="userCheck" style="color:red"></a>
						<a style="color:red"><form:errors path="loginName"/></a>
						<form:input id="loginName" path="loginName" />
						</td>
					</tr>
					<tr>
						<th class="facility-info-th">password</th>
						<td>
						<a class="passCheck" style="color:red"></a>
						<a style="color:red"><form:errors path="password1"/></a>
						<form:input id="password1" path="password1" />
						</td>
					</tr>
					<tr>
						<th class="facility-info-th">password<br>※もう一度入力してください
						</th>
						<td>
						<a style="color:red"><form:errors path="password2"/></a>
						<form:input id="password2" path="password2" /></td>
					</tr>
					<tr>
						<th class="facility-info-th">権限</th>
						<td>
							<form:radiobutton path="parmissionLevel" value="1" label="管理者" checked="checked" />
							<form:radiobutton path="parmissionLevel" value="2" label="ユーザー" />
						</td>
					</tr>
					<tr>
						<th class="facility-info-th">備考</th>
						<td>
						<a style="color:red"><form:errors path="note"/></a>
						<form:textarea id="facility-info-remarks" rows="10"
								maxlength="200" path="note" /></td>
					</tr>
				</table>
				<input type="button" class="addButton" name="add" value="確認" />
				<input type="button"  value="戻る"  onClick="location.href='/user/list'"/>
			</form:form>
		</div>
		<div id="footer">
			<p class="copyright">(C) 2003 Ginga Software, All Rights
				Reserved..</p>
		</div>
	</div>
	
	<!-- javascriptの記述 -->
	<script type="text/javascript">
		$(function(){
			$('.addButton').click(function(){
				resetMessage();
				
				var pass1 = $('#password1').val();
				var pass2 = $('#password2').val();
				
				if(pass1 != pass2){
					$('.passCheck').text('パスワード不一致');
				} else{
					var userId = $('#loginName').val();
					$.ajax({
						url :'/userCheck',
						type : 'post',
						data : JSON.stringify({"loginName":userId}),
						dataType : 'json',
						contentType : 'application/json ; charset=utf-8'
					}).done(function(data, Status, jqXHR){
						if(data == 0){
								$('.addButton').attr('type', 'submit');
								$('.addButton').click();
						}else {
							$('.userCheck').text('ユーザーIDが既に使用されています。');
						}
						
					}).fail(function(jqXHR, status, errorThrown){
						alert(jqXHR.status);
					});
				}
			});
		});
		
		
		function resetMessage(){
			$('a').text('');
		}
	</script>
</body>
</html>