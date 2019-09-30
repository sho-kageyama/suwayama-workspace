package jp.co.ginga.domain.service.imp;

import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import jp.co.ginga.domain.entity.FacilityEntity;
import jp.co.ginga.domain.repository.FacilityRepository;
import jp.co.ginga.domain.repository.StubFacilityRepository;

@RunWith(SpringRunner.class)
@SpringBootTest
public class FacilityServiceImpTest {

	@Autowired
	FacilityServiceImp facilityServiceImp;

	//@Ignore
	@Test
	public void getFacilityListTest_OK_001() {

		/**
		 * テストデータ作成
		 */
		int id = 1;
		String name = "testNm";
		int typeId = 1;
		int capacity = 1;
		String userId = "testUser";

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {

			@Override
			public List<FacilityEntity> findAll() {
				List<FacilityEntity> facilityList = new ArrayList<FacilityEntity>();

				FacilityEntity facility = new FacilityEntity();
				facility.setId(id);
				facility.setName(name);
				facility.setTypeId(typeId);
				facility.setCapacity(capacity);
				facility.setUserId(userId);
				facilityList.add(facility);
				return facilityList;
			}
		};

		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * セットしたものがゲットできるかのチェック
		 */
		FacilityRepository test = facilityServiceImp.getRepoFacility();
		System.out.println("RepoFacilityのテスト -----> " + test);

		/**
		 * テストメソッドの呼び出し
		 */
		List<FacilityEntity> facilityList = facilityServiceImp.getFacilityList();

		System.out.println("facility : findAll OK Test用施設名は -----> "+facilityList.get(0).getName());

		/**
		 * テストデータとテストメソッドで取得した値が同値かチェック
		 */
		assertEquals(id, facilityList.get(0).getId());
		assertEquals(name, facilityList.get(0).getName());
		assertEquals(typeId, facilityList.get(0).getTypeId());
		assertEquals(capacity, facilityList.get(0).getCapacity());
		assertEquals(userId, facilityList.get(0).getUserId());
	}
	//@Ignore
	@Test
	public void getFacilityListTest_NG_001() {

		try {

		/**
		 * レポジトリをスタブでインスタンス生成し、例外をはかせる
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public List<FacilityEntity> findAll() {
				throw new IllegalArgumentException();
			}
		};

		/**
		 * サービスに例外スタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		List<FacilityEntity> facilityList = facilityServiceImp.getFacilityList();
		System.out.println("facility : findAll NG fail() -----> " + facilityList);
		fail();

		}catch (IllegalArgumentException e){
			System.out.println("facility : findAll NG 例外名は -----> " + e);
		}
	}
	//@Ignore
	@Test
	public void getFacilityTest_OK_001(){

		/**
		 * テストデータ作成
		 */
		int id = 1;
		String name = "testNm";
		int typeId = 1;
		int capacity = 1;
		String userId = "testUser";

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public FacilityEntity findOneById(int i) {

				FacilityEntity facility = new FacilityEntity();
				facility.setId(id);
				facility.setName(name);
				facility.setTypeId(typeId);
				facility.setCapacity(capacity);
				facility.setUserId(userId);

				return facility;
			}
		};

		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		FacilityEntity facility = facilityServiceImp.getFacility(id);

		System.out.println("facility : findOne OK Test用施設名は -----> "+facility.getName());

		/**
		 * テストデータとテストメソッドで取得した値が同値かチェック
		 */
		assertEquals(id, facility.getId());
		assertEquals(name, facility.getName());
		assertEquals(typeId, facility.getTypeId());
		assertEquals(capacity, facility.getCapacity());
		assertEquals(userId, facility.getUserId());
	}
	//@Ignore
	@Test
	public void getFacilityTest_NG_001() {

		/**
		 * テストデータ作成
		 */
		int id = 1;

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public FacilityEntity findOneById(int i) {
				FacilityEntity facility = new FacilityEntity();
				return facility;
			}
		};

		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		FacilityEntity facility = facilityServiceImp.getFacility(id);

		System.out.println("facility : findOne NG 異常系 Test用施設名は ----->" + facility.getName());

		/**
		 * 存在しない施設IDはintなので0が返ってくるはず
		 * 存在しない施設名はnullになるはず
		 */
		assertEquals(0 , facility.getId());
		assertNull(facility.getName());
	}
	//@Ignore
	@Test
	public void getFacilityTest_NG_002() {

		try {

		/**
		 * テストデータ作成
		 */
		int id = 1;

		/**
		 * レポジトリをスタブでインスタンス生成し、例外をはかせる
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public FacilityEntity findOneById(int i) {
				throw new IllegalArgumentException();
			}
		};

		/**
		 * サービスに例外スタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		FacilityEntity facility = facilityServiceImp.getFacility(id);
		System.out.println("facility : findAll NG fail() -----> " + facility);
		fail();

		}catch (IllegalArgumentException e){
			System.out.println("facility : findOne NG 例外系 例外名は -----> " + e);
		}
	}
//	@Ignore
	@Test
	public void deleteTest_OK_001() {

		/**
		 * テストデータ作成
		 */
		int id = 1;

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public boolean delete(int i) {
			return true;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int delete = facilityServiceImp.delete(id);

		System.out.println("facility : delete OK 成功時の値は -----> " + delete);

		assertEquals(1 , delete);
	}
//	@Ignore
	@Test
	public void deleteTest_NG_001() {

		/**
		 * テストデータ作成
		 */
		int id = 1;

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public boolean delete(int i) {
			return false;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int delete = facilityServiceImp.delete(id);

		System.out.println("facility : delete NG 異常系 失敗時の値は -----> " + delete);

		assertEquals(0 , delete);
	}
//	@Ignore
	@Test
	public void deleteTest_NG_002() {

		try {

		/**
		 * テストデータ作成
		 */
		int id = 1;

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public boolean delete(int i) {
				throw new IllegalArgumentException();
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		int delete = facilityServiceImp.delete(id);
		System.out.println("facility : delete NG 例外系 fail() -----> " + delete);
		fail();

		}catch(IllegalArgumentException e){
			System.out.println("facility : delete NG 例外系 例外名は -----> " + e);
		}
	}
//	@Ignore
	@Test
	public void updateTest_OK_001() {

		/**
		 * テストデータの作成
		 */
		FacilityEntity facility = new FacilityEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public boolean update(FacilityEntity facility) {
			return true;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int update = facilityServiceImp.update(facility);

		System.out.println("facility : update OK 成功時の値は -----> " + update);

		assertEquals(1 , update);
	}
//	@Ignore
	@Test
	public void updateTest_NG_001() {

		/**
		 * テストデータ作成
		 */
		FacilityEntity facility = new FacilityEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public boolean update(FacilityEntity facility) {
			return false;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int update = facilityServiceImp.update(facility);

		System.out.println("facility : update NG 異常系 失敗時の値は -----> " + update);

		assertEquals(0 , update);
	}
//	@Ignore
	@Test
	public void updateTest_NG_002() {

		try {

		/**
		 * テストデータ作成
		 */
			FacilityEntity facility = new FacilityEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public boolean update(FacilityEntity facility) {
				throw new IllegalArgumentException();
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		int update = facilityServiceImp.update(facility);
		System.out.println("facility : update NG 例外系 fail() -----> " + update);
		fail();

		}catch(IllegalArgumentException e){
			System.out.println("facility : update NG 例外系 例外名は -----> " + e);
		}
	}
//	@Ignore
	@Test
	public void addTest_OK_001() {

		/**
		 * テストデータの作成
		 */
		FacilityEntity facility = new FacilityEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public boolean add(FacilityEntity facility) {
			return true;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int add = facilityServiceImp.add(facility);

		System.out.println("facility : add OK 成功時の値は -----> " + add);

		assertEquals(1 , add);
	}
//	@Ignore
	@Test
	public void addTest_NG_001() {

		/**
		 * テストデータ作成
		 */
		FacilityEntity facility = new FacilityEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {
			@Override
			public boolean add(FacilityEntity facility) {
			return false;
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * テストメソッドの呼び出し
		 */
		int add = facilityServiceImp.add(facility);

		System.out.println("facility : add NG 異常系 失敗時の値は -----> " + add);

		assertEquals(0 , add);
	}
//	@Ignore
	@Test
	public void addTest_NG_002() {

		try {

		/**
		 * テストデータ作成
		 */
			FacilityEntity facility = new FacilityEntity();

		/**
		 * レポジトリをスタブでインスタンス生成し、テストデータで上書き
		 */
		FacilityRepository stub = new StubFacilityRepository() {

			@Override
			public boolean add(FacilityEntity facility) {
				// TODO 自動生成されたメソッド・スタブ
				throw new IllegalArgumentException();
			}
		};
		/**
		 * サービスにスタブをセット
		 */
		facilityServiceImp.setRepoFacility(stub);

		/**
		 * 例外がキャッチされるはずなのでこちらは通ってはいけない
		 */
		int add = facilityServiceImp.add(facility);
		System.out.println("facility : add NG 例外系 fail() -----> " + add);
		fail();

		}catch(IllegalArgumentException e){
			System.out.println("facility : add NG 例外系 例外名は -----> " + e);
		}
	}
}
