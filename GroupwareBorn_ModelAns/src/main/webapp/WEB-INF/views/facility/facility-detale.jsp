<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>施設情報更新・削除</title>
<meta charset="UTF-8">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<!-- jQueryの読み込み -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<!-- jQueryUiの読み込み -->
<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">
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
			<div id="view-title">施設情報管理</div>

		<div id="dialog">
			<table style="margin:auto;">
				<tr>
					<th>facility :   </th>
					<td><font size="5">${facilityFormSession.name}</font></td>
				</tr>
			</table>
		</div>


			<!--
            <ul class="msgs">
                <li>エラーメッセージ表示エリア</li>
            </ul>
             -->
			<p id="contents-title">施設情報の更新、削除を行えます</p>
			<form:form modelAttribute="facilityFormSession" action="/facility/confilm" method="post">

			<form:input type="hidden" path="id" value="${id}" />

				<table id="facility-info">
					<tr>
						<th class="facility-info-th">施設名</th>
						<td>
						<a style="color:red"><form:errors path="name"/></a>
						<form:input class="name" path="name" /></td>
					</tr>
					<tr>
						<th class="facility-info-th">種別</th>
						<td>
						<c:forEach items="${list}" var="type" varStatus="loop">
							<c:choose>
								<c:when test="${loop.count==1}">
									<form:radiobutton path="typeId" value="${type.id}" label="${type.name}" checked="checked" />
								</c:when>
								<c:otherwise>
									<form:radiobutton path="typeId" value="${type.id}" label="${type.name}" />
								</c:otherwise>
							</c:choose>
						</c:forEach>
						</td>
					</tr>
					<tr>
						<th class="facility-info-th">定員</th>
						<td>
						<a style="color:red"><form:errors path="capacity"/></a>
						<form:input class="capacity" path="capacity" /></td>
					</tr>

				</table>
				<input type="button" class="update"  name="update" value="更新">
				<input type="button" class="delete" name="delete" value="削除">
				<input type="button"  value="戻る" onClick="location.href='/facility/list'"/>
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
			$('.update').click(function(){
					$('.update').attr('type','submit');
			});


			$('.delete').click(function(){
				$('#dialog').dialog('open');
			});

			$('#dialog').dialog({
				autoOpen :false,
				modal : true,
				title : 'DeleteFacility',
				buttons :{
					'OK' : function(){
						$(this).dialog('close');
						$('form').attr('action', '/facility/complete');
						$('.delete').attr('type','submit');
						$('.delete').click();
					},
					'cancel' : function() {
						$(this).dialog('close');

					}
				}

			});



		});

	</script>
</body>
</html>