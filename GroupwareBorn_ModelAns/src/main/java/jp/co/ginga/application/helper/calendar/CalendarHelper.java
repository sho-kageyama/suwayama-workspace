package jp.co.ginga.application.helper.calendar;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

import org.springframework.stereotype.Component;

import jp.co.ginga.application.form.facilityreservation.CalendarListForm;
import jp.co.ginga.application.form.facilityreservation.DayForm;
import jp.co.ginga.application.form.facilityreservation.ReservationDetailForm;

@Component
public class CalendarHelper {

	public CalendarListForm getNow() {
		CalendarListForm form = new CalendarListForm();
		Calendar calendar = Calendar.getInstance();
		int year = calendar.get(Calendar.YEAR);
		int month = calendar.get(Calendar.MONTH) + 1;

		form.setYear(year);
		form.setMonth(month);

		return form;
	}

	public int getWeekOfDay(int year, int month) {
		Calendar calendar = Calendar.getInstance();

		calendar.set(year, (month - 1), 1);
		int week = calendar.get(Calendar.DAY_OF_WEEK);

		if (week == 1) {
			week = 6;
		} else {
			week -= 2;
		}

		return week;
	}

	public int getDays(int year, int month) {
		Calendar calendar = Calendar.getInstance();

		calendar.set(year, (month - 1), 1);

		int days = calendar.getActualMaximum(Calendar.DATE);

		return days;
	}

	public CalendarListForm nextMonth(CalendarListForm calendarForm) {
		int year = calendarForm.getYear();
		int month = calendarForm.getMonth() + 1;

		if (month > 12) {
			year += 1;
			month = 1;
		}

		calendarForm.setYear(year);
		calendarForm.setMonth(month);

		return calendarForm;
	}

	public CalendarListForm prevMonth(CalendarListForm calendarForm) {
		int year = calendarForm.getYear();
		int month = calendarForm.getMonth() - 1;

		if (month < 1) {
			year -= 1;
			month = 12;
		}

		calendarForm.setYear(year);
		calendarForm.setMonth(month);

		return calendarForm;
	}

	public List<DayForm> makeCalendar(int dayOfWeek, int days, List<ReservationDetailForm> reservationList) {
		List<DayForm> calendarList = new ArrayList<>();

		int total = days + dayOfWeek;
		int result = total % 7;
		int tail;

		if(result == 0) {
			tail = 0;
		} else {
			tail = 7 - result;
		}

		System.out.println("--------------------------");
		System.out.println("dayOfWeek :"+dayOfWeek);
		System.out.println("days      :"+days);
		System.out.println("tail      :"+tail);

		for (int i = 1; i <= total + tail; i++) {
			DayForm calendar = new DayForm();
			if (dayOfWeek != 0 && i < dayOfWeek) {
				calendar.setDay(0);
			} else if (tail != 0 && i > total) {
				calendar.setDay(0);
			} else {
				int day = i - dayOfWeek;
				calendar.setDay(day);
				List<ReservationDetailForm> reserved = new ArrayList<>();
				for (ReservationDetailForm reservation : reservationList) {
					if (reservation.getDay() == day) {
						reserved.add(reservation);
					}
				}
				calendar.setReservationList(reserved);
			}
			calendarList.add(calendar);
		}
		return calendarList;
	}

}
