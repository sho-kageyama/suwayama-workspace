/**
 *
 */
package jp.co.ginga.application.controller.facility;

import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.SessionAttributes;
import org.springframework.web.bind.support.SessionStatus;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import jp.co.ginga.application.form.facility.FacilityForm;
import jp.co.ginga.application.form.facility.FacilityListForm;
import jp.co.ginga.application.form.session.AccountSessionForm;
import jp.co.ginga.application.helper.facility.FacilityHelper;
import jp.co.ginga.domain.entity.FacilityEntity;
import jp.co.ginga.domain.entity.FacilityTypeEntity;
import jp.co.ginga.domain.service.FacilityService;
import jp.co.ginga.domain.service.FacilityTypeService;

/**
 * 施設コントローラー
 *
 * @author yoshi
 *
 */
@Controller
@SessionAttributes(names = "facilityFormSession")
public class FacilityController {

	private static final String FORM_NAME = "facilityFormSession";

	/**
	 * サービス
	 */
	@Autowired
	FacilityService service;
	@Autowired
	FacilityTypeService typeService;

	/**
	 * セッション
	 */
	@Autowired
	AccountSessionForm sessionForm;

	/**
	 * ヘルパー
	 */
	@Autowired
	FacilityHelper helper;

	/**
	 * 施設コントローラー内で使用するセッションオブジェクトの生成処理
	 *
	 * @return
	 */
	@ModelAttribute(value = "facilityFormSession")
	public FacilityForm facilityForm() {
		return new FacilityForm();
	}

	/**
	 * 施設一覧画面遷移処理
	 *
	 * @return
	 */
	@RequestMapping(path = "/facility/list", method = RequestMethod.GET)
	public String createFacilityListFormGet(Model model) {

		// 施設一覧データ取得処理
		List<FacilityEntity> facilityEntityList = service.getFacilityList();

		//施設種別一覧データ取得処理
		List<FacilityTypeEntity> typeEntityList = typeService.getFacilityTypeList();

		// データ変換処理
		List<FacilityForm> facilityAndTypeFormList = helper.convertFromFacilityEntityListAndFacilityTypeEntityListToFacilityFormList(facilityEntityList, typeEntityList);

		// 施設一覧画面Formオブジェクト生成
		FacilityListForm form = new FacilityListForm();

		// 施設一覧情報設定処理
		form.setFacilityList(facilityAndTypeFormList);

		// ビューへの値設定処理
		model.addAttribute("facilityListForm", form);

		return "facility/facility-list";
	}

	/**
	 * 施設登録画面遷移処理
	 *
	 * @return
	 */
	@RequestMapping(path = "/facility/add", method = RequestMethod.GET)
	public String createFacilityAddFormGet(@ModelAttribute(FORM_NAME) FacilityForm session, ModelMap model) {

		String key = BindingResult.MODEL_KEY_PREFIX + FORM_NAME;

		//施設種別一覧データ取得処理
		List<FacilityTypeEntity> typeEntityList = typeService.getFacilityTypeList();
		model.addAttribute("list",typeEntityList);

		if (model.containsKey("errors")) {
			model.addAttribute(key, model.get("errors"));
		} else {


			model.addAttribute("facilityFormSession", session);
		}

		// セッションオブジェクトを設定する処理

		return "facility/facility-add";

	}

	/**
	 * 施設詳細情報画面遷移処理
	 *
	 * @return
	 */
	@RequestMapping(path = "/facility/detail/{id}", method = RequestMethod.GET)
	public String createFacilityDetailGet(@PathVariable int id, ModelMap model) {

		String key = BindingResult.MODEL_KEY_PREFIX + FORM_NAME;

		// 施設IDから施設情報の取得
		FacilityEntity facility = service.getFacility(id);
			model.addAttribute("id",id);

		//施設種別一覧データ取得処理
		List<FacilityTypeEntity> typeEntityList = typeService.getFacilityTypeList();
		model.addAttribute("list",typeEntityList);

		// データ変換処理
		FacilityForm facilityForm = helper.convertFromFacilityEntityToFacilityForm(facility);

		if (model.containsKey("errors")) {
			model.addAttribute(key, model.get("errors"));
		} else {
			model.addAttribute("facilityFormSession", facilityForm);
		}

		// ModelオブジェクトへFormオブジェクトを登録する処理
		return "facility/facility-detale";

	}

	/**
	 * 施設情報確認画面遷移処理
	 *
	 * @return
	 * @throws Exception
	 */
	@RequestMapping(path = "/facility/confilm", params = "add", method = RequestMethod.POST)
	public String createFacilityConfilmeAddPost(@ModelAttribute(FORM_NAME) @Valid FacilityForm session, BindingResult result,
			Model model, RedirectAttributes ra) throws Exception {

		// バリデータチェック処理
		if (result.hasErrors()) {
			ra.addFlashAttribute("errors", result);
			return "redirect:/facility/add";
		}

		//施設種別一覧データ取得処理
		String typeName = typeService.getFacilityTypeName(session.getTypeId());
		model.addAttribute("typeName",typeName);

		// 確認画面表示オブジェクト生成処理

		// ModelオブジェクトへFormオブジェクトを登録する処理
		model.addAttribute("facilityFormSession", session);

		model.addAttribute("btnName", "登録");
		model.addAttribute("btnAction", "add");
		return "facility/facility-confilm";
	}

	/**
	 * 施設情報確認画面遷移処理
	 *
	 * @return
	 */
	@RequestMapping(path = "/facility/confilm", params = "update", method = RequestMethod.POST)
	public String createFacilityConfilmeUpdatePost(@ModelAttribute(FORM_NAME) @Valid FacilityForm session,
			BindingResult result, Model model, RedirectAttributes ra) throws Exception {

		if (result.hasErrors()) {
			ra.addFlashAttribute("errors", result);
			return "redirect:/facility/detail/" + session.getId() + "";
		}

		//施設種別一覧データ取得処理
		String typeName = typeService.getFacilityTypeName(session.getTypeId());
		model.addAttribute("typeName",typeName);

		model.addAttribute("btnName", "更新");
		model.addAttribute("btnAction", "update");

		return "facility/facility-confilm";
	}

	/**
	 * 施設情報登録完了画面遷移処理
	 *
	 * @return
	 */
	@RequestMapping(path = "/facility/complete", params = "add", method = RequestMethod.POST)
	public String createFacilityCompleteGet(FacilityForm session, SessionStatus sessionStatus, Model model) {

		FacilityEntity facility = helper.convertEntityFacilityForm(session);
		String userId = sessionForm.getAccountName();
		facility.setUserId(userId);

		int result = service.add(facility);
		if (result != 1) {
			return "error/error";
		}

		// セッションの破棄
		sessionStatus.setComplete();

		return "facility/facility-complete";
	}

	/**
	 * 施設情報更新完了画面遷移処理
	 *
	 * @return
	 */
	@RequestMapping(path = "/facility/complete", params = "update", method = RequestMethod.POST)
	public String createFacilityCompleteUpdatePost(FacilityForm session, SessionStatus sessionStatus, Model model) {

		FacilityEntity facility = helper.convertEntityFacilityForm(session);
		String userId = sessionForm.getAccountName();
		facility.setUserId(userId);

		int result = service.update(facility);
		if (result != 1) {
			return "error/error";
		}
		// セッションの破棄
		sessionStatus.setComplete();

		return "facility/facility-complete";
	}

	/**
	 * 施設情報削除完了画面遷移処理
	 *
	 * @return
	 */
	@RequestMapping(path = "/facility/complete", params = "delete", method = RequestMethod.POST)
	public String createFacilityCompleteDeletePost(FacilityForm session, SessionStatus sessionStatus, Model model) {

		FacilityEntity facility = helper.convertEntityFacilityForm(session);

		int result = service.delete(facility.getId());

		if (result != 1) {
			return "error";
		}

		// セッションの破棄
		sessionStatus.setComplete();
		return "facility/facility-complete";
	}

	/**
	 * 施設戻るボタン遷移処理
	 *
	 * @return
	 */
	@RequestMapping(path = "/facility/back/{name}", method = RequestMethod.GET)
	public String facilityBack(@PathVariable String name, @ModelAttribute(FORM_NAME) FacilityForm facilityForm) {

		if (name.equals("add")) {
			return "redirect:/facility/add";
		} else if (name.equals("update")) {
			return "redirect:/facility/detail/" + facilityForm.getId() + "";
		}


		return "error/error";
	}

}
