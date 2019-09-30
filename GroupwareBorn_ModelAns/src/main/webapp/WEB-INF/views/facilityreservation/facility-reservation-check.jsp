<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>予約内容確認</title>
<meta charset="UTF-8">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
</head>
<body>
	<div id="base">
		<jsp:include page="/WEB-INF/views/header/header.jsp" flush="true" />
		<div id="contents">
			<div id="view-title">予約内容確認</div>
			<p id="contents-title">以下の内容で予約します。よろしいですか？</p>
			<form action="/facility-reservations/complete" method="post">
				<table id="reservation-check" border="1">
					<tr>
						<th>予約施設</th>
						<td>${facilityReservationForm.facility.name}</td>
					</tr>
					<tr>
						<th>予約日</th>
						<td>${facilityReservationForm.year}年${facilityReservationForm.month}月${facilityReservationForm.day}日</td>
					</tr>
					<tr>
						<th>予約時間</th>
						<td>${facilityReservationForm.startTime}~${facilityReservationForm.endTime}</td>
					</tr>
				</table>
				<p>
					<input type="button" value="戻る" onClick="history.back();">
					<input type="submit" value="確定"/>
				</p>
			</form>
        </div>
		<jsp:include page="/WEB-INF/views/footer/footer.jsp" flush="true" />
	</div>
</body>
</html>