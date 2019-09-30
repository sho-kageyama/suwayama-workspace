<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>予約情報更新・削除</title>
<meta charset="UTF-8">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
</head>
<body>
	<div id="base">
		<jsp:include page="/WEB-INF/views/header/header.jsp" flush="true" />
		<div id="contents">
			<div id="view-title">予約情報管理</div>
			<spring:eval var="accountSessionForm" expression="@accountSessionForm"/>
			<c:if test="${facilityReservationForm.userId == accountSessionForm.accountName || accountSessionForm.permissionLevel == 1}">
				<p id="contents-title">予約情報の更新、削除を行えます</p>
			</c:if>
			<form:form modelAttribute="facilityReservationForm" method="post">
				<a class="timeCheck" style="color:red;"><form:errors path="multiError"/></a>
				<p>${facilityReservationForm.facility.name}</p>
				<p>${facilityReservationForm.year}年${facilityReservationForm.month}月${facilityReservationForm.day}日</p>
				<table id="facility-info">
					<tr>
						<th class="facility-info-th">
							最終更新者
							<br>
							<font size="1px" style="color:red;">※ユーザー名は変更できません</font>
						</th>
					</tr>
					<tr>
						<td>
							<a class="userCheck" style="color:red"></a>
							<form:input path="userId" value="${facilityReservationForm.userId}" readonly="true"/>
						</td>
					</tr>
					<tr>
						<th class="facility-info-th">予約開始時間</th>
					</tr>
					<tr>
						<td>
							<p>
								<form:select path="reservationInfo.startHour" class="select startHour">
									<c:forEach begin="9" end="21" step="1" var="hour">
									<c:choose>
									<c:when test="${hour == facilityReservationForm.reservationInfo.startHour}">
										<option value="${hour}" selected="selected">${hour}</option>
									</c:when>
									<c:otherwise>
										<option value="${hour}">${hour}</option>
									</c:otherwise>
									</c:choose>
								</c:forEach>
								</form:select>時 <form:select path="reservationInfo.startMinute" class="select startMinute" value="${facilityReservationForm.reservationInfo.startMinute}">

								<c:forEach begin="00" end="45" step="15" var="minute">
									<c:choose>
									<c:when test="${minute == facilityReservationForm.reservationInfo.startMinute}">
										<option value="${minute}" selected="selected">${minute}</option>
									</c:when>
									<c:otherwise>
										<option value="${minute}">${minute}</option>
									</c:otherwise>
									</c:choose>
								</c:forEach>
								</form:select>分
							</p>
						</td>
					</tr>
					<tr><th class="facility-info-th">予約終了時間</th></tr>
					<tr>
						<td>
							<p>
								<form:select path="reservationInfo.endHour" class="select endHour">
								<c:forEach begin="9" end="21" step="1" var="hour">
									<c:choose>
									<c:when test="${hour == facilityReservationForm.reservationInfo.endHour}">
									<option value="${hour}" selected="selected">${hour}</option>
									</c:when>
									<c:otherwise>
									<option value="${hour}">${hour}</option>
									</c:otherwise>
									</c:choose>
								</c:forEach>
								</form:select>時 <form:select path="reservationInfo.endMinute" class="select endMinute">
								<c:forEach begin="00" end="45" step="15" var="minute">
									<c:choose>
									<c:when test="${minute == facilityReservationForm.reservationInfo.endMinute}">
										<option value="${minute}" selected="selected">${minute}</option>
									</c:when>
									<c:otherwise>
										<option value="${minute}">${minute}</option>
									</c:otherwise>
									</c:choose>
								</c:forEach>
								</form:select>分
							</p>
						</td>
					</tr>
				</table>
				<c:if test="${facilityReservationForm.userId == accountSessionForm.accountName || accountSessionForm.permissionLevel == 1}">
					<input type="button" class="update" value="更新">
					<input type="submit" name="delete" value="削除" onclick='return confirm("削除しますか？");'>
				</c:if>
				<div id="return-display">
					<a href="/facility-reservations/${facilityReservationForm.facility.id}">前のページに戻る</a>
				</div>
			</form:form>
		</div>
		<jsp:include page="/WEB-INF/views/footer/footer.jsp" flush="true" />
	</div>

	<script>
	$('input.update').click(function(){
		var startTime = Number($('.startHour').val()) + parseFloat('0.'+$('.startMinute').val());
		console.log(startTime);

		var endTime = Number($('.endHour').val()) + parseFloat('0.'+$('.endMinute').val());
		console.log(endTime);

		if(endTime - startTime > 0){
			if(confirm("更新しますか？")){
				$('form').submit();
			} else {
				return false;
			}
		}else{
			$('a.timeCheck').text('終了時刻は開始時刻より後');
		}
	});

	$('select.select').change(function(){
		var startHour = $('.startHour').val();
		var endHour = $('.endHour').val();
		if(endHour - startHour <= 0 && startHour != 21){
			var etime = Number(startHour) + 1;
			$('.endHour').val(etime);
		}else if(startHour == 21){
			$('.endHour').val(21);
			$('.endMinute').val(15);
		}
	});
	</script>
</body>
</html>