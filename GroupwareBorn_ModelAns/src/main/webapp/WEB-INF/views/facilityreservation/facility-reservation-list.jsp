
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>施設一覧</title>
<meta charset="UTF-8">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
</head>
<body>
	<div id="base">
		<jsp:include page="/WEB-INF/views/header/header.jsp" flush="true" />
		<div id="contents">
			<div id="view-title">施設一覧</div>
			<p id="contents-title">施設を選択してください。</p>
			<select class="selectObj">
				<option selected="selected" value="0">すべて</option>
				<c:forEach var="type" items="${facilityListForm.typeList}">
					<option value="${type.id}">${type.name}</option>
				</c:forEach>
			</select>

			<ul id="facility">
			<c:forEach var="facilityInfo" items="${facilityListForm.facilityList}">
				<li class="facility-list"><input class="${facilityInfo.id}" type="button"
					value="${facilityInfo.name} : 定員 ${facilityInfo.capacity} 人"
					onFocus="selectFacility();" /></li>
			</c:forEach>
			</ul>
		</div>
		<div id="return-display">
			<a href="/menu">前のページに戻る</a>
		</div>
		<jsp:include page="/WEB-INF/views/footer/footer.jsp" flush="true" />
	</div>

	<script>
	$('select.selectObj').change(function(){
		var id = $(this).val();
		$.ajax({
			url : '/facility-reservations/facility-type/select',
			type : 'post',
			data : JSON.stringify({'typeId':id}),
			dataType : 'json',
			contentType : 'application/json ; charset=UTF-8'
		}).done(function(data,status,jqXHR){
			
			$('ul#facility').empty();
		
			for(var i in data){
				var facility = '<li class="facility-list">'
								+'<input class="'+data[i].id+'"'
								+'type="button"'
								+'value="'+data[i].name+' : 定員 '+data[i].capacity+' 人"'
								+'onFocus="selectFacility();" /></li>';
				$('ul#facility').append(facility);
			}

		}).fail(function(jqXHR,status,errorThrown){
			alert(jqXHR.status);
		});
	});

	function selectFacility(){
		$('li.facility-list input').click(function(){
			location.href='/facility-reservations/'+$(this).attr('class');
		});
	}
	</script>
</body>
</html>