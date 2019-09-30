<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>施設予約</title>
<meta charset="UTF-8">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js" ></script>
</head>
<body>
	<div id="base">
		<jsp:include page="/WEB-INF/views/header/header.jsp" flush="true" />
		<div id="contents">
			<div id="view-title">施設予約</div>
			<!--
            <ul class="msgs">
                <li>エラーメッセージ表示エリア</li>
            </ul>
             -->
			<p id="contents-title">予約時間を選択してください。</p>

			<form:form modelAttribute="facilityReservationForm" action="/facility-reservations/check" method="post">
				<a class="timeCheck" style="color:red;"><form:errors path="multiError"/></a>
				<p>${facilityReservationForm.facility.name}</p>
				<p>${facilityReservationForm.year}年${facilityReservationForm.month}月${facilityReservationForm.day}日</p>

				<p>
					予約開始時間 <form:select path="reservationInfo.startHour" class="select startHour">
						<option value="9" selected="selected">9</option>
						<c:forEach begin="10" end="21" step="1" var="hour">
							<option value="${hour}">${hour}</option>
						</c:forEach>
					</form:select>時 <form:select path="reservationInfo.startMinute" class="select startMinute">
						<option value="00" selected="selected">00</option>
						<c:forEach begin="15" end="45" step="15" var="minute">
							<option value="${minute}">${minute}</option>
						</c:forEach>
					</form:select>分
				</p>

				<p>
					予約終了時間 <form:select path="reservationInfo.endHour" class="select endHour">
						<c:forEach begin="9" end="21" step="1" var="hour">
						<c:choose>
						<c:when test="${hour == 10}">
							<option value="${hour}" selected="selected">${hour}</option>
						</c:when>
						<c:otherwise>
							<option value="${hour}">${hour}</option>
						</c:otherwise>
						</c:choose>
						</c:forEach>
					</form:select>時 <form:select path="reservationInfo.endMinute" class="endMinute">
						<option value="00" selected="selected">00</option>
						<c:forEach begin="15" end="45" step="15" var="minute">
							<option value="${minute}">${minute}</option>
						</c:forEach>
					</form:select>分
				</p>

				<form:input type="hidden" path="facility.id" value="${facilityReservationForm.facility.id}"/>
				<form:input type="hidden" path="day" value="${facilityReservationForm.day}"/>
	
				<sec:authentication property="principal" var="userDetail"/>
				<form:input type="hidden" path="userId" value="${(userDetail.username)}"/>

				<input type="button" class="reservation" value="予約" />

			</form:form>
		</div>
		<div id="return-display">
			<a href="javascript:history.back();">前のページに戻る</a>
		</div>
		<jsp:include page="/WEB-INF/views/footer/footer.jsp" flush="true" />
	</div>

	<script>
	$('input.reservation').click(function(){
		var startTime = Number($('.startHour').val()) + parseFloat('0.'+$('.startMinute').val());
		console.log(startTime);

		var endTime = Number($('.endHour').val()) + parseFloat('0.'+$('.endMinute').val());
		console.log(endTime);

		if(endTime - startTime > 0){
			$('form').submit();
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