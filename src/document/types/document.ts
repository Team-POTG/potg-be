export type DocumentType = {
  path: string;
  module: Function[];
  builder?: {
    title: string;
    description: string;
    version: string;
  };
};
