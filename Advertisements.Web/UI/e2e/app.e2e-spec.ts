import { UIPage } from './app.po';

describe('ui App', () => {
  let page: UIPage;

  beforeEach(() => {
    page = new UIPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
