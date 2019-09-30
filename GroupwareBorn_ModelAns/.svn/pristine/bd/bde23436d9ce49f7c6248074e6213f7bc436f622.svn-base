package jp.co.ginga.domain.service.imp;

import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import jp.co.ginga.domain.entity.FacilityTypeEntity;
import jp.co.ginga.domain.repository.FacilityTypeRepository;
import jp.co.ginga.domain.repository.StubFacilityTypeRepository;

@RunWith(SpringRunner.class)
@SpringBootTest
public class FacilityTypeServiceImpTest {

	@Autowired
	FacilityTypeServiceImp typeServiceImp;

	//@Ignore
	@Test
	public void getFacilityTypeListTest_OK_001() {

		/**
		 * テストデータ作成
		 */
		int id = 1;
		String name = "testNm";

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityTypeRepository stub = new StubFacilityTypeRepository() {

			@Override
			public List<FacilityTypeEntity> findAll() {
				List<FacilityTypeEntity> typeList = new ArrayList<FacilityTypeEntity>();

				FacilityTypeEntity type = new FacilityTypeEntity();
				type.setId(id);
				type.setName(name);
				typeList.add(type);
				return typeList;
			}
		};

		/**
		 * サービスにスタブをセット
		 */
		typeServiceImp.setRepoType(stub);

		/**
		 * セットしたものがゲットできるかのチェック
		 */
		FacilityTypeRepository test = typeServiceImp.getRepoType();
		System.out.println("RepoTypeのテスト -----> " + test);

		/**
		 * テストメソッドの呼び出し
		 */
		List<FacilityTypeEntity> typeList = typeServiceImp.getFacilityTypeList();

		System.out.println("type : findAll OK Test用施設種別IDは -----> "+typeList.get(0).getId());

		/**
		 * テストデータとテストメソッドで取得した値が同値かチェック
		 */
		assertEquals(id, typeList.get(0).getId());
		assertEquals(name, typeList.get(0).getName());
	}
	//@Ignore
	@Test
	public void FacilityTypeListTest_NG_001() {

		try {

		/**
		 * レポジトリをスタブでインスタンス生成し、例外をはかせる
		 */
		FacilityTypeRepository stub = new StubFacilityTypeRepository() {
			@Override
			public List<FacilityTypeEntity> findAll() {
				throw new IllegalArgumentException();
			}
		};

		/**
		 * サービスに例外スタブをセット
		 */
		typeServiceImp.setRepoType(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		List<FacilityTypeEntity> typeList = typeServiceImp.getFacilityTypeList();
		System.out.println("type : findAll NG fail() -----> " + typeList);
		fail();

		}catch (IllegalArgumentException e){
			System.out.println("type : findAll NG 例外名は -----> " + e);
		}
	}
	//@Ignore
	@Test
	public void getFacilityTypeNameTest_OK_001(){

		/**
		 * テストデータ作成
		 */
		int id = 1;
		String name = "testNm";

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityTypeRepository stub = new StubFacilityTypeRepository() {
			@Override
			public String findTypeName(int i) {
				String type = name;
				return type;
			}
		};

		/**
		 * サービスにスタブをセット
		 */
		typeServiceImp.setRepoType(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		String type = typeServiceImp.getFacilityTypeName(id);

		System.out.println("type : findTypeName OK Test用ユーザ名は -----> "+ type);

		/**
		 * テストデータとテストメソッドで取得した値が同値かチェック
		 */
		assertEquals("testNm", type);

	}
	//@Ignore
	@Test
	public void getFacilityTypeNameTest_NG_001() {

		/**
		 * テストデータ作成
		 */
		int id = 1;

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityTypeRepository stub = new StubFacilityTypeRepository();

		/**
		 * サービスにスタブをセット
		 */
		typeServiceImp.setRepoType(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		String type = typeServiceImp.getFacilityTypeName(id);

		System.out.println("type : findTypeName NG 異常系 Test用ユーザ名は ----->" + type);

		/**
		 * 存在しない施設種別IDではNullが返ってくるはず
		 */
		assertNull(type);
	}
	//@Ignore
	@Test
	public void getFacilityTypeNameTest_NG_002() {

		try {

		/**
		 * テストデータ作成
		 */
		int id = 1;

		/**
		 * レポジトリをスタブでインスタンス生成し、例外をはかせる
		 */
		FacilityTypeRepository stub = new StubFacilityTypeRepository() {
			@Override
			public String findTypeName(int i) {
				throw new IllegalArgumentException();
			}
		};

		/**
		 * サービスに例外スタブをセット
		 */
		typeServiceImp.setRepoType(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		String type = typeServiceImp.getFacilityTypeName(id);
		System.out.println("type : findTypeName NG fail() -----> " + type);
		fail();

		}catch (IllegalArgumentException e){
			System.out.println("type : findTypeName NG 例外系 例外名は -----> " + e);
		}
	}
}
